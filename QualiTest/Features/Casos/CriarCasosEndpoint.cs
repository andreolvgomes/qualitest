using FastEndpoints;
using Infra.Repositories;

namespace QualiTest.Features.Casos
{
    public class CasosRequest
    {
        public Guid Projeto_id { get; set; }
        public Guid Parent_id { get; set; }
        public string Nome { get; set; }
    }

    [HttpPost("casos")]
    public class CriarCasosEndpoint : Endpoint<CasosRequest>
    {
        private readonly IRepositoryBase<NodesEntity> _repository;
        private readonly ICasosRepository _casosRepository;

        public CriarCasosEndpoint(IRepositoryBase<NodesEntity> repository,
            ICasosRepository casosRepository)
        {
            _repository = repository;
            _casosRepository = casosRepository;
        }

        public async override Task HandleAsync(CasosRequest req, CancellationToken ct)
        {
            var nodes = await _repository.Create(new NodesEntity
            {
                Projeto_id = req.Projeto_id,
                Parent_id = req.Parent_id,
                Nome  = req.Nome,
                Tipo = "caso"
            });

            var entity = await _casosRepository.Create(new CasosEntity
            {
                 Node_id = nodes.Id
            });
            await Send.OkAsync(entity, ct);
        }
    }
}