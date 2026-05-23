using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    [HttpDelete("casos/{id:Guid}")]
    public class DeleteCasosEndpoint : Endpoint<CasosEntity>
    {
        private readonly IRepositoryBase<CasosEntity> _repository;

        public DeleteCasosEndpoint(IRepositoryBase<CasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CasosEntity req, CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}