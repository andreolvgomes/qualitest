using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpDelete("projetos/{id:Guid}")]
    public class DeleteProjetoEndpoint : Endpoint<ProjetosEntity>
    {
        private readonly IProjetosRepository _projetosRepository;

        public DeleteProjetoEndpoint(IProjetosRepository projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(ProjetosEntity req, CancellationToken ct)
        {
            await _projetosRepository.Delete(Route<Guid>("id"));
            await Send.OkAsync();
        }
    }
}