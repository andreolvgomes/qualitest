using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    public class CasosResponse : CasosEntity
    {
        public IEnumerable<PassosEntity> Passos { get; set; }
    }

    [HttpGet("casos/{id:Guid}")]
    public class GetCasosEndpoint : Endpoint<CasosEntity>
    {
        private readonly IRepositoryBase<CasosEntity> _repository;
        private readonly IRepositoryBase<PassosEntity> _passosRepository;

        public GetCasosEndpoint(IRepositoryBase<CasosEntity> repository,
            IRepositoryBase<PassosEntity> passosRepository)
        {
            _repository = repository;
            _passosRepository = passosRepository;
        }

        public async override Task HandleAsync(CasosEntity req, CancellationToken ct)
        {
            var id = Route<Guid>("id");
            var resultCaso = await _repository.Get(id);
            var resultPassos = await _passosRepository.GetAll(new { caso_id = id });

            await Send.OkAsync(new CasosResponse
            {
                Id = resultCaso.Id,
                Created_at = resultCaso.Created_at,
                Node_id = resultCaso.Node_id,
                Pre_condicoes = resultCaso.Pre_condicoes,
                Resultado_esperado = resultCaso.Resultado_esperado,
                Passos = resultPassos
            });
        }
    }
}