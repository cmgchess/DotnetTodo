using Model = Todo.Interface.DataModels;

namespace Todo.Interface.Services
{
    public interface ITodosService
    {
        Task<List<Model.Todo>> GetAll();
        Task<Model.Todo?> GetById(int id);
        Task<Model.Todo?> Create(Model.Todo todo);
        Task<Model.Todo?> Delete(int id);
        Task<Model.Todo?> Activate(int id);
        Task<Model.Todo?> Deactivate(int id);
        Task<Model.Todo?> Update(Model.Todo todo);
    }
}
