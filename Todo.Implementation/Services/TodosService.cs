using Model = Todo.Interface.DataModels;
using Todo.Interface.Services;

namespace Todo.Implementation.Services
{
    public class TodosService : ITodosService
    {
        private static readonly List<Model.Todo> _todoList = new List<Model.Todo>
        {
            new Model.Todo { Id = 1, Description = "Wake up", Active = true },
            new Model.Todo { Id = 2, Description = "Breakfast", Active = false },
            new Model.Todo { Id = 3, Description = "Shopping", Active = false },
            new Model.Todo { Id = 4, Description = "Gym", Active = false}
        };

        public async Task<List<Model.Todo>> GetAll()
        {
            return _todoList.ToList();
        }

        public async Task<Model.Todo?> GetById(int id)
        {
            var todo = _todoList.FirstOrDefault(todo => todo.Id == id);

            if (todo == null)
            {
                return null;
            }

            return todo;
        }

        public async Task<List<Model.Todo>?> Create(Model.Todo todo)
        {
            var todoExists = _todoList.Exists(t => t.Id == todo.Id);
            if (todoExists)
            {
                return null;
            }

            _todoList.Add(todo);
            return _todoList;
        }

        public async Task<List<Model.Todo>?> Delete(int id)
        {
            var todoToRemove = _todoList.FirstOrDefault(todo => todo.Id == id);
            if (todoToRemove == null)
            {
                return null;
            }
            _todoList.Remove(todoToRemove);
            return _todoList;
        }

        public async Task<Model.Todo?> Activate(int id)
        {
            var todoToActivate = _todoList.FirstOrDefault(todo => todo.Id == id);
            if (todoToActivate == null)
            {
                return null;
            }

            todoToActivate.Active = true;
            return todoToActivate;
        }

        public async Task<Model.Todo?> Deactivate(int id)
        {
            var todoToDeactivate = _todoList.FirstOrDefault(todo => todo.Id == id);
            if (todoToDeactivate == null)
            {
                return null;
            }
            todoToDeactivate.Active = false;
            return todoToDeactivate;
        }

        public async Task<Model.Todo?> Update(Model.Todo todo)
        {
            var todoToUpdate = _todoList.FirstOrDefault(t => t.Id == todo.Id);
            if (todoToUpdate == null)
            {
                return null;
            }
            todoToUpdate.Description = todo.Description;
            todoToUpdate.Active = todo.Active;
            return todoToUpdate;
        }

    }
}
