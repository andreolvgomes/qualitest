using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpDelete("planos/planoscasos/{id:Guid}")]
    public class DeletePlanosCasosEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<PlanoCasosEntity> _repository;

        public DeletePlanosCasosEndpoint(IRepositoryBase<PlanoCasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await _repository.Delete(Route<Guid>("id"));
            await Send.OkAsync(ct);
        }
    }
}