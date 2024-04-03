using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private static readonly List<Todo> _todoList = new List<Todo>
        {
            new Todo { Id = 1, Description = "Wake up", Active = true },
            new Todo { Id = 2, Description = "Breakfast", Active = false },
            new Todo { Id = 3, Description = "Shopping", Active = false },
        };

        private readonly ILogger<TodoListController> _logger;

        public TodoListController(ILogger<TodoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("todos")]
        public IActionResult GetAll()
        {
            return Ok(_todoList.ToList());
        }

        [HttpGet]
        [Route("todos/{id}")]
        public IActionResult GetById(int id)
        {
            var todo = _todoList.Find(todo => todo.Id == id);

            if (todo == null)
            {
                return NotFound("Todo not found");
            }

            return Ok(todo);
        }

        [HttpPost]
        [Route("todos")]
        public IActionResult Create([FromBody] Todo todo)
        {
            var todoExists = _todoList.Exists(t => t.Id == todo.Id);
            if (todoExists)
            {
                return BadRequest("Cannot add Todo with same ID");
            }

            _todoList.Add(todo);
            return Ok(_todoList);
        }

        [HttpDelete]
        [Route("todos/{id}")]
        public IActionResult Delete(int id)
        {
            var todoToRemove = _todoList.Find(todo => todo.Id == id);
            if (todoToRemove == null)
            {
                return NotFound("Todo not found");
            }
            _todoList.Remove(todoToRemove);
            return Ok(_todoList);
        }

        [HttpPatch]
        [Route("todos/activate/{id}")]
        public IActionResult Acticate(int id)
        {
            var todoToActivate = _todoList.Find(todo => todo.Id == id);
            if (todoToActivate == null)
            {
                return NotFound("Todo not found");
            }

            if (todoToActivate.Active)
            {
                return BadRequest("Todo already active");
            }
            todoToActivate.Active = true;
            return Ok(todoToActivate);
        }

        [HttpPatch]
        [Route("todos/deactivate/{id}")]
        public IActionResult Deactivate(int id)
        {
            var todoToActivate = _todoList.Find(todo => todo.Id == id);
            if (todoToActivate == null)
            {
                return NotFound("Todo not found");
            }


            if (!todoToActivate.Active)
            {
                return BadRequest("Todo already inactive");
            }
            todoToActivate.Active = false;
            return Ok(todoToActivate);
        }

        [HttpPut]
        [Route("todos/{id}")]
        public IActionResult Update(int id, [FromBody] TodoUpdate todo)
        {
            var todoToUpdate = _todoList.Find(todo => todo.Id == id);

            if (todoToUpdate == null)
            {
                return NotFound("Todo not found");
            }

            todoToUpdate.Description = todo.Description;
            todoToUpdate.Active = todo.Active;

            return Ok(todoToUpdate);
        }

    }

}
