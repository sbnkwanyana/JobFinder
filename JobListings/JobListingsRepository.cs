using JobFinder.Data;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.JobListings
{
    public class JobListingRepository : IJobListingRepository
    {
        private readonly JobFinderContext _context;

        public JobListingRepository(JobFinderContext context)
        {
            _context = context;
        }

        public async Task<Task> Add(JobListing jobListing)
        {
            await _context.JobListings.AddAsync(jobListing);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<Task> Delete(int? id)
        {
            var jobListing = await _context.JobListings.FindAsync(id);
            if (jobListing == null)
            {
                return Task.CompletedTask;
            }
            _context.JobListings.Remove(jobListing);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<JobListing>> GetAll()
        {
            return await _context.JobListings.ToListAsync();
             
        }

        public JobListing? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(JobListing jobListing)
        {
            throw new NotImplementedException();
        }
    }
}