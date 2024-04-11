namespace Todo.Interface.Dtos
{
    public class CreateTodoReqeustDto
    {
        public string Description { get; set; } = default!;
        public bool Active { get; set; }
    }
}
