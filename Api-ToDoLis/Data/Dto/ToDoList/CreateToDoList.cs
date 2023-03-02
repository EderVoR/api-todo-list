namespace Api_ToDoLis.Data.Dto.ToDoList
{
    public class CreateToDoList
    {
        public string Titulo { get; set; }
        public string? Observacao { get; set; }
        public DateTime DataInclusao { get; set; }
        public int? Tipo_Id { get; set; }
    }
}
