using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Planos
{
    [HttpPost("planos/planoscasos")]
    public class CriarPlanosCasosEndpoint : Endpoint<PlanoCasosEntity>
    {
        private readonly IRepositoryBase<PlanoCasosEntity> _repository;

        public CriarPlanosCasosEndpoint(IRepositoryBase<PlanoCasosEntity> repository)
        {
            _repository = repository;
        }

        public async override Task HandleAsync(PlanoCasosEntity req, CancellationToken ct)
        {
            var entity = await _repository.Create(req);
            await Send.OkAsync(req, ct);
        }
    }
}