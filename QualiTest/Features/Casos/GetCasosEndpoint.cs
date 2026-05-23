using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpGet("casos/{id:Guid}")]
    public class GetCasosEndpoint : Endpoint<CasosEntity>
    {
        private readonly IRepositoryBase<CasosEntity> _repository;

        public GetCasosEndpoint(IRepositoryBase<CasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Get(Route<Guid>("id")));
        }
    }
}