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
        public IActionResult Get()
        {
            return Ok(_todoList.ToList());
        }

        [HttpGet]
        [Route("todos/{id}")]
        public IActionResult Get(int id)
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
        public IActionResult Post([FromBody] Todo todo)
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
        [Route("todos/{state}/{id}")]
        public IActionResult Patch(string state, int id)
        {
            var todoToActivate = _todoList.Find(todo => todo.Id == id);
            if (todoToActivate == null)
            {
                return NotFound("Todo not found");
            }


            if (state == "activate")
            {
                if (todoToActivate.Active)
                {
                    return BadRequest("Todo already active");
                }
                todoToActivate.Active = true;
                return Ok(todoToActivate);
            }

            if (state == "deactivate")
            {
                if (!todoToActivate.Active)
                {
                    return BadRequest("Todo already inactive");
                }
                todoToActivate.Active = false;
                return Ok(todoToActivate);
            }

            return BadRequest("Invalid action");
        }

        [HttpPut]
        [Route("todos/{id}")]
        public IActionResult Put(int id, [FromBody] TodoUpdate todo)
        {
            var todoToUpdate = _todoList.Find(todo => todo.Id == id);

            if (todoToUpdate == null) {
                return NotFound("Todo not found");
            }

            todoToUpdate.Description = todo.Description;
            todoToUpdate.Active = todo.Active;

            return Ok(todoToUpdate);
        }

    }

}
