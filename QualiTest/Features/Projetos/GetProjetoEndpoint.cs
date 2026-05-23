using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpGet("projetos/{id:Guid}")]
    public class GetProjetoEndpoint : EndpointWithoutRequest
    {
        private readonly IProjetosRepository _projetosRepository;

        public GetProjetoEndpoint(IProjetosRepository projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await Send.OkAsync(await _projetosRepository.GetById(Route<Guid>("id")));
        }
    }
}