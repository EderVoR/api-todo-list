namespace Api_ToDoLis.Models
{
    public class TipoLista
    {
        public int Id { get; set; }
        public String Descricao_tipo { get; set; }
        public int? Ativo { get; set; }
        public virtual ToDoList ToDoList { get; set; }
    }
}
