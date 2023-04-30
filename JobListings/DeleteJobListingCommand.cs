using MediatR;

namespace JobFinder.JobListings
{
    public record  DeleteJobListingCommand(int? id):  IRequest;
    public class DeleteJobListingCommandHandler : IRequestHandler<DeleteJobListingCommand>
    {
        private readonly IJobListingRepository _repository;

        public DeleteJobListingCommandHandler(IJobListingRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteJobListingCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.id);
        }
    }
}