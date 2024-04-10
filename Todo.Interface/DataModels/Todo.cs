namespace Todo.Interface.DataModels
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public bool Active { get; set; }

    }
}
