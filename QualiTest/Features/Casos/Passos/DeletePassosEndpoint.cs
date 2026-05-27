using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos.Passos
{
    [HttpDelete("casos/{caso_id:Guid}/passos/{id:Guid}")]
    public class DeletePassosEndpoint : Endpoint<PassosEntity>
    {
        private readonly IRepositoryBase<PassosEntity> _repository;

        public DeletePassosEndpoint(IRepositoryBase<PassosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PassosEntity req, CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}