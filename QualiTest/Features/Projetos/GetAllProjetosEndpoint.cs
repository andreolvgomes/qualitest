using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpGet("projetos")]
    public class GetAllProjetosEndpoint : EndpointWithoutRequest
    {
        private readonly IProjetosRepository _projetosRepository;

        public GetAllProjetosEndpoint(IProjetosRepository projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await Send.OkAsync(await _projetosRepository.GetAll());
        }
    }
}