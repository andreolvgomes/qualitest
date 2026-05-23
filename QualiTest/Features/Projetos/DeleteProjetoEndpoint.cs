using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpDelete("projetos/{id:Guid}")]
    public class DeleteProjetoEndpoint : EndpointWithoutRequest
    {
        private readonly IProjetosRepository _projetosRepository;

        public DeleteProjetoEndpoint(IProjetosRepository projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await _projetosRepository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}