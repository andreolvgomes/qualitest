using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Suites
{
    [HttpGet("suites/{id:Guid}")]
    public class GetSuitesEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<SuitesEntity> _repository;

        public GetSuitesEndpoint(IRepositoryBase<SuitesEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Get(Route<Guid>("id")));
        }
    }
}
