using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpPost("projetos")]
    public class CriarProjetosEndpoint : Endpoint<ProjetosEntity>
    {
        private readonly IRepositoryBase<ProjetosEntity> _projetosRepository;

        public CriarProjetosEndpoint(IRepositoryBase<ProjetosEntity> projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(ProjetosEntity req, CancellationToken ct)
        {
            var entity = await _projetosRepository.Create(req);
            await Send.OkAsync(entity);
        }
    }
}