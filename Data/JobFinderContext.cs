using Microsoft.EntityFrameworkCore;
using JobFinder.JobListings;

namespace JobFinder.Data;

public class JobFinderContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public JobFinderContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JobListing>().ToTable("JobListings");
        modelBuilder.Entity<JobListing>().HasData(SeedData.JobListings);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlite(_configuration.GetConnectionString("JobFinderConnection"));
        optionsBuilder.UseSqlite(@"Data Source=JobFinderDatabase.db");
    }

    public DbSet<JobListing> JobListings { get; set; } = default!;
}