using MediatR;

namespace JobFinder.JobListings;

public record GetJobListingsQuery : IRequest<IEnumerable<JobListing>>;

public class GetJobListingsQueryHandler : IRequestHandler<GetJobListingsQuery, IEnumerable<JobListing>>
{
  private readonly IJobListingRepository _repository;

  public GetJobListingsQueryHandler(IJobListingRepository repository)
  {
    _repository = repository;
  }

  public async Task<IEnumerable<JobListing>> Handle(GetJobListingsQuery request, CancellationToken cancellationToken)
  {
    return await _repository.GetAll();
  }
}