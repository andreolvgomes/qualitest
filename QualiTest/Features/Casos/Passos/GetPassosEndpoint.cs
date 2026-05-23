using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos.Passos
{
    [HttpGet("passos/{id:Guid}")]
    public class GetPassosEndpoint : Endpoint<PassosEntity>
    {
        private readonly IRepositoryBase<PassosEntity> _repository;

        public GetPassosEndpoint(IRepositoryBase<PassosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PassosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Get(Route<Guid>("id")));
        }
    }
}