using DapperExtensions;

namespace Infra.Repositories
{
    [Table("projetos")]
    public class ProjetosEntity : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Inativo { get; set; }
    }

    [Table("nodes")]
    public class NodesEntity : EntityBase
    {
        public Guid Projeto_id { get; set; }
        public Guid? Parent_id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public Int16 Ordem { get; set; }
        public bool Inativo { get; set; }
    }

    [Table("suites")]
    public class SuitesEntity : EntityBase
    {
        public Guid Node_id { get; set; }
        public string Pre_condicoes { get; set; }
    }

    [Table("casos")]
    public class CasosEntity : EntityBase
    {
        public Guid Node_id { get; set; }
        public string Pre_condicoes { get; set; }
        public string Resultado_esperado { get; set; }
    }

    [Table("passos")]
    public class PassosEntity : EntityBase
    {
        public Guid Caso_id { get; set; }
        public Int16 Ordem { get; set; }
        public string Acao { get; set; }
        public string Resultado_esperado { get; set; }
    }

    [Table("planos")]
    public class PlanosEntity : EntityBase
    {
        public Guid Projeto_id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    [Table("planocasos")]
    public class PlanoCasosEntity : EntityBase
    {
        public Guid Plano_id { get; set; }
        public Guid Caso_id { get; set; }
    }
}