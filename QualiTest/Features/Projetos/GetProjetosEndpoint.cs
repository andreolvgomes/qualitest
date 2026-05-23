using Infra.Repositories;
using FastEndpoints;

namespace QualiTest.Features.Projetos
{
    [HttpGet("projetos/{id:Guid}")]
    public class GetProjetosEndpoint : EndpointWithoutRequest
    {
        private readonly IRepositoryBase<ProjetosEntity> _projetosRepository;

        public GetProjetosEndpoint(IRepositoryBase<ProjetosEntity> projetosRepository)
        {
            _projetosRepository = projetosRepository;
        }

        public async override Task HandleAsync(CancellationToken ct)
        {
            await Send.OkAsync(await _projetosRepository.Get(Route<Guid>("id")));
        }
    }
}