namespace JobFinder.JobListings;

public class JobListing
{
    
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Company { get; set; }
    public string? Location { get; set; }
    public string? Url { get; set; }
    public DateTime? DatePosted { get; set; }
}