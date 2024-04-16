namespace Todo.Interface.DataModels;

public partial class Todo
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public bool Active { get; set; }
}
