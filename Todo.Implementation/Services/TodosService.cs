using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Todo.Implementation.Data;
using Todo.Interface.Dtos;
using Todo.Interface.Services;
using Model = Todo.Interface.DataModels;

namespace Todo.Implementation.Services
{
    public class TodosService : ITodosService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TodosService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Model.Todo>> GetAll()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Model.Todo?> GetById(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null)
            {
                return null;
            }

            return todo;
        }

        public async Task<Model.Todo?> Create(CreateTodoReqeustDto todo)
        {
            var todoToCreate = _mapper.Map<Model.Todo>(todo);
            await _context.Todos.AddAsync(todoToCreate);
            await _context.SaveChangesAsync();
            return todoToCreate;
        }

        public async Task<Model.Todo?> Delete(int id)
        {
            var todoToRemove = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (todoToRemove == null)
            {
                return null;
            }
            _context.Todos.Remove(todoToRemove);
            await _context.SaveChangesAsync();
            return todoToRemove;
        }

        public async Task<Model.Todo?> Activate(int id)
        {
            var todoToActivate = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (todoToActivate == null)
            {
                return null;
            }

            todoToActivate.Active = true;
            await _context.SaveChangesAsync();
            return todoToActivate;
        }

        public async Task<Model.Todo?> Deactivate(int id)
        {
            var todoToDeactivate = await _context.Todos.FirstOrDefaultAsync(todo => todo.Id == id);
            if (todoToDeactivate == null)
            {
                return null;
            }
            todoToDeactivate.Active = false;
            await _context.SaveChangesAsync();
            return todoToDeactivate;
        }

        public async Task<Model.Todo?> Update(Model.Todo todo)
        {
            var todoToUpdate = await _context.Todos.FirstOrDefaultAsync(t => t.Id == todo.Id);
            if (todoToUpdate == null)
            {
                return null;
            }
            todoToUpdate.Description = todo.Description;
            todoToUpdate.Active = todo.Active;
            await _context.SaveChangesAsync();
            return todoToUpdate;
        }

    }
}
