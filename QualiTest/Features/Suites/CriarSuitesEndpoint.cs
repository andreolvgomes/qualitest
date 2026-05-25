using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Suites
{
    public class SuitesRequest
    {
        public Guid Projeto_id { get; set; }
        public Guid Parent_id { get; set; }
        public string Nome { get; set; }
    }

    [HttpPost("suites")]
    public class CriarSuitesEndpoint : Endpoint<SuitesRequest>
    {
        private readonly IRepositoryBase<SuitesEntity> _repository;
        private readonly IRepositoryBase<NodesEntity> _nodesRepository;

        public CriarSuitesEndpoint(IRepositoryBase<SuitesEntity> repository,
            IRepositoryBase<NodesEntity> nodesRepository)
        {
            _repository = repository;
            _nodesRepository = nodesRepository;
        }

        public async override Task HandleAsync(SuitesRequest req, CancellationToken ct)
        {
            var nodes = await _nodesRepository.Create(new NodesEntity
            {
                Projeto_id = req.Projeto_id,
                Parent_id = req.Parent_id,
                Nome = req.Nome,
                Tipo = "suite"
            });

            var entity = await _repository.Create(new SuitesEntity
            {
                Node_id = nodes.Id
            });

            await Send.OkAsync(entity);
        }
    }
}