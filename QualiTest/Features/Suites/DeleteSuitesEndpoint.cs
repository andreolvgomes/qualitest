using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Suites
{
    [HttpDelete("suites/{id:Guid}")]
    public class DeleteSuitesEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<SuitesEntity> _repository;

        public DeleteSuitesEndpoint(IRepositoryBase<SuitesEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}
