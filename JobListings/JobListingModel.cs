using System.ComponentModel.DataAnnotations;

namespace JobFinder.JobListings
{
    public class JobListingModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }
}