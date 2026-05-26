using Dapper;
using System.Data;

namespace Infra.Repositories
{
    public interface INodesRepository : IRepositoryBase<NodesEntity>
    {
        Task<IEnumerable<object>> GetArvore(Guid projeto_id, Guid? node_id = null);
    }

    public class NodesRepository : RepositoryBase<NodesEntity>, INodesRepository
    {
        public NodesRepository(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<object>> GetArvore(Guid projeto_id, Guid? node_id = null)
        {
            var sql = @"
SELECT 
    nodes.*,
    casos.id as caso_id,
    suites.id as suite_id,
    casos.node_id,
    casos.pre_condicoes,
    casos.resultado_esperado    
FROM nodes
LEFT JOIN casos ON nodes.id = casos.node_id
LEFT JOIN suites ON nodes.id = suites.node_id
WHERE nodes.projeto_id = @projeto_id AND nodes.inativo = false";

            if (node_id is not null)
                sql += " and nodes.id = @node_id";

            sql += "\n ORDER BY nodes.ordem";

            return await _connection.QueryAsync(sql, new { projeto_id, node_id });
        }
    }
}