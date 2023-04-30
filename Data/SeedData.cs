using JobFinder.JobListings;

namespace JobFinder.Data;

public static class SeedData
{
    public static JobListing[] JobListings
    {
        get
        {
            return new JobListing[]
            {
                new JobListing{ Id = 1, Title="C#Developer",Company="Google", Description="C# Programmer", Location="Johannesburg, South Africa", DatePosted=DateTime.Now },
                new JobListing{ Id = 2, Title="JavaScript/TypeScript Developer", Company="Amazon", Description="Node Developer", Location="Cape Town, South Africa", DatePosted=DateTime.Parse("2023-04-28") },
                new JobListing{ Id = 3, Title="Python Developer", Company="Microsoft", Description="Data Science Developer", Location="Durban, South Africa", DatePosted=DateTime.Parse("2022-12-30") },
            };
        }
    }
}