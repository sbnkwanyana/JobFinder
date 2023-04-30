using MediatR;

namespace JobFinder.JobListings;

public record AddJobListingCommand(string Title, string Description, string Company, string Location) : IRequest;

public class AddJobListingCommandHandler : IRequestHandler<AddJobListingCommand>
{
    private readonly IJobListingRepository _repository;

    public AddJobListingCommandHandler(IJobListingRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(AddJobListingCommand request, CancellationToken cancellationToken)
    {
        await _repository.Add(new JobListing(){
            Title = request.Title,
            Description = request.Description,
            Company = request.Company,
            Location = request.Location, 
            DatePosted = DateTime.Now,
        });
    }

}