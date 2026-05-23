using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos.Passos
{
    [HttpGet("passos")]
    public class GetAllPassosEndpoint : Endpoint<PassosEntity>
    {
        private readonly IRepositoryBase<PassosEntity> _repository;

        public GetAllPassosEndpoint(IRepositoryBase<PassosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PassosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.GetAll());
        }
    }
}