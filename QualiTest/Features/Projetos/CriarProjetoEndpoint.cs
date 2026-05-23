using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpPost("projetos")]
    public class CriarProjetoEndpoint : Endpoint<ProjetosEntity>
    {
        private readonly IProjetosRepository _projetosRepository;

        public CriarProjetoEndpoint(IProjetosRepository projetosRepository)
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