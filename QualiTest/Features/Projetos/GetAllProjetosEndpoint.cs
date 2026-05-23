using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpGet("projetos")]
    public class GetAllProjetosEndpoint : Endpoint<ProjetosEntity>
    {
        private readonly IProjetosRepository _projetosRepository;

        public GetAllProjetosEndpoint(IProjetosRepository projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(ProjetosEntity req, CancellationToken ct)
        {
            await Send.OkAsync(await _projetosRepository.GetAll());
        }
    }
}