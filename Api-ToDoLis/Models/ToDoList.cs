using System.ComponentModel.DataAnnotations;

namespace Api_ToDoLis.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int Concluido { get; set; }
        public int? Tipo_Id { get; set; }
        public virtual TipoLista TipoLista { get; set; }
    }
}
