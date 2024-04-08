using TestProject.Models;

namespace TestProject.Interface
{
    public interface ITodosService
    {
        Task<List<Todo>> GetAll();
        Task<Todo?> GetById(int id);
        Task<List<Todo>?> Create(Todo todo);
        Task<List<Todo>?> Delete(int id);
        Task<Todo?> Activate(int id);
        Task<Todo?> Deactivate(int id);
        Task<Todo?> Update(Todo todo);
    }
}
