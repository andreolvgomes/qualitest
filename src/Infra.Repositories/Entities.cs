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

    [Table("casos_nos")]
    public class CasosNosEntity : EntityBase
    {
        public Guid Projeto_id { get; set; }
        public Guid? Parent_id { get; set; }
        public string Nome { get; set; }
        public bool Caso_teste { get; set; }
        public Int16 Ordem { get; set; }
        public bool Inativo { get; set; }
    }
}
