using JobFinder.JobListings;
using JobFinder.Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>()
    //.AddBehavior<IPipelineBehavior<AddJobListingCommand, Unit>, AddJobListingBehavior>());
    .AddOpenBehavior(typeof(LoggingBehavior<,>)));
builder.Services.AddDbContext<JobFinderContext>();
builder.Services.AddScoped<IJobListingRepository, JobListingRepository>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<JobListingModel>, JobListingValidator>();
builder.Host.UseSerilog((context, configuration) => 
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

var app = builder.Build();


app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
