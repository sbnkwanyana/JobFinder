namespace JobFinder.JobListings;

public interface IJobListingRepository
{
    JobListing? GetById(int id);
    Task<Task> Add(JobListing jobListing);
    void Update(JobListing jobListing);
    Task<Task> Delete(int? id);
    Task<IEnumerable<JobListing>> GetAll();
}