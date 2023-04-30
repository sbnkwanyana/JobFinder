using JobFinder.JobListings;
using JobFinder.Data;
using FluentValidation.AspNetCore;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddDbContext<JobFinderContext>();
builder.Services.AddScoped<IJobListingRepository, JobListingRepository>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<JobListingModel>, JobListingValidator>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
