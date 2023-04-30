using FluentValidation;

namespace JobFinder.JobListings;

public class JobListingValidator : AbstractValidator<JobListingModel> 
{
    public JobListingValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Company).NotEmpty();
        RuleFor(x => x.Location).NotEmpty();
    }
}