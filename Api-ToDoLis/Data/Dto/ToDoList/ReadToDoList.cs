using Api_ToDoLis.Models;

namespace Api_ToDoLis.Data.Dto.ToDoList
{
    public class ReadToDoList
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int Concluido { get; set; }
        public int? Tipo_Id { get; set; }
        public virtual Models.TipoLista TipoLista { get; set; }
    }
}
