using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpGet("casos")]
    public class GetAllCasosEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<CasosEntity> _repository;

        public GetAllCasosEndpoint(IRepositoryBase<CasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await Send.OkAsync(await _repository.GetAll());
        }
    }
}