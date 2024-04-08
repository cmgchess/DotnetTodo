using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Services
{
    public class TodosService : ITodosService
    {
        private static readonly List<Todo> _todoList = new List<Todo>
        {
            new Todo { Id = 1, Description = "Wake up", Active = true },
            new Todo { Id = 2, Description = "Breakfast", Active = false },
            new Todo { Id = 3, Description = "Shopping", Active = false },
            new Todo { Id = 4, Description = "Gym", Active = false}
        };

        public async Task<List<Todo>> GetAll()
        {
            return _todoList.ToList();
        }

        public async Task<Todo?> GetById(int id)
        {
            var todo = _todoList.FirstOrDefault(todo => todo.Id == id);

            if (todo == null)
            {
                return null;
            }

            return todo;
        }

        public async Task<List<Todo>?> Create(Todo todo)
        {
            var todoExists = _todoList.Exists(t => t.Id == todo.Id);
            if (todoExists)
            {
                return null;
            }

            _todoList.Add(todo);
            return _todoList;
        }

        public async Task<List<Todo>?> Delete(int id)
        {
            var todoToRemove = _todoList.FirstOrDefault(todo => todo.Id == id);
            if (todoToRemove == null)
            {
                return null;
            }
            _todoList.Remove(todoToRemove);
            return _todoList;
        }

        public async Task<Todo?> Activate(int id)
        {
            var todoToActivate = _todoList.FirstOrDefault(todo => todo.Id == id);
            if (todoToActivate == null)
            {
                return null;
            }

            todoToActivate.Active = true;
            return todoToActivate;
        }

        public async Task<Todo?> Deactivate(int id)
        {
            var todoToDeactivate = _todoList.FirstOrDefault(todo => todo.Id == id);
            if (todoToDeactivate == null)
            {
                return null;
            }
            todoToDeactivate.Active = false;
            return todoToDeactivate;
        }

        public async Task<Todo?> Update(Todo todo)
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
