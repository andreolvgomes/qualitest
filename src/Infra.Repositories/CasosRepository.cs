using System.Data;
using Dapper;

namespace Infra.Repositories
{
    public interface ICasosRepository : IRepositoryBase<CasosEntity>
    {
        Task<IEnumerable<object>> Casos(Guid projeto_id, Guid? node_id = null);
    }
    public class CasosRepository : RepositoryBase<CasosEntity>, ICasosRepository
    {
        public CasosRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public async Task<IEnumerable<object>> Casos(Guid projeto_id, Guid? node_id = null)
        {
            var sql = @"
SELECT 
    nodes.*,
    casos.pre_condicoes,
    casos.resultado_esperado
FROM nodes
LEFT JOIN casos ON nodes.id = casos.node_id
WHERE nodes.projeto_id = @projeto_id AND nodes.inativo = false";

            if (node_id is not null)
                sql += " and nodes.id = @node_id";

            sql += "\n ORDER BY nodes.ordem";

            return await _connection.QueryAsync(sql, new { projeto_id, node_id });
        }
    }
}
