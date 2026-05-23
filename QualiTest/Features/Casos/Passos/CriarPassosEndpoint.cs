using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos.Passos
{
    [HttpPost("passos")]
    public class CriarPassosEndpoint : Endpoint<PassosEntity>
    {
        private readonly IRepositoryBase<PassosEntity> _repository;

        public CriarPassosEndpoint(IRepositoryBase<PassosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PassosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _repository.Create(req));
        }
    }
}