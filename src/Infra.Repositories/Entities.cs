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

    [Table("nos")]
    public class NosEntity : EntityBase
    {
        public Guid Projeto_id { get; set; }
        public Guid? Parent_id { get; set; }
        public string Nome { get; set; }
        public bool Caso_teste { get; set; }
        public Int16 Ordem { get; set; }
        public bool Inativo { get; set; }
    }

    [Table("casos")]
    public class CasosEntity : EntityBase
    {
        public Guid Nos_id { get; set; }
        public string Pre_condicoes { get; set; }
        public string Resultado_esperado { get; set; }
    }

    [Table("passos")]
    public class PassosEntity : EntityBase
    {
        public Guid Casos_id { get; set; }
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
        public Guid Planos_id { get; set; }
        public Guid Casos_id { get; set; }
    }
}