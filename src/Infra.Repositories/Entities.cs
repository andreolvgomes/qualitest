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
}
