using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JobFinder.Models;
using MediatR;
using JobFinder.JobListings;
using FluentValidation;
using FluentValidation.Results;
using FluentValidation.AspNetCore;

namespace JobFinder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    private readonly IValidator<JobListingModel> _validator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator, IValidator<JobListingModel> validator)
    {
        _logger = logger;
        _mediator = mediator;
        _validator = validator;
    }
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> JobListings()
    {
        var query = new GetJobListingsQuery();
        var result = await _mediator.Send(query);
        return View(result);
    }
    [HttpPost]
    [HttpGet]
    public async Task<IActionResult> NewJobListing([FromForm] JobListingModel model)
    {
        if (Request.Method == "POST" && model != null)
        {
            ValidationResult result = _validator.Validate(model);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(model);
            }
            var command = new AddJobListingCommand(model.Title, model.Description, model.Company, model.Location);
            await _mediator.Send(command);
            return RedirectToAction("JobListings");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteJobListing(int? id)
    {
        if (id == null)
        {
            return BadRequest();
        }
        var command = new DeleteJobListingCommand(id);
        await _mediator.Send(command);
        return RedirectToAction("JobListings");
    }
}
