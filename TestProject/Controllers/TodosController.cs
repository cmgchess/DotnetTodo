using Microsoft.AspNetCore.Mvc;
using TestProject.Interfaces;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodosService _todosService;

        public TodosController(ITodosService todosService)
        {
            _todosService = todosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todosService.GetAll();
            return Ok(todos);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todosService.GetById(id);

            if (todo == null)
            {
                return NotFound("Todo not found");
            }

            return Ok(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Todo todo)
        {
            var newTodoList = await _todosService.Create(todo);
            if (newTodoList == null)
            {
                return BadRequest("Cannot add Todo with same ID");
            }
            return Ok(newTodoList);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todoToRemove = await _todosService.Delete(id);
            if (todoToRemove == null)
            {
                return NotFound("Todo not found");
            }
            return Ok(todoToRemove);
        }

        [HttpPatch]
        [Route("{id}/activate")]
        public async Task<IActionResult> Activate(int id)
        {
            var todoToActivate = await _todosService.Activate(id);
            if (todoToActivate == null)
            {
                return NotFound("Todo not found");
            }

            return Ok(todoToActivate);
        }

        [HttpPatch]
        [Route("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var todoToDeactivate = await _todosService.Deactivate(id);
            if (todoToDeactivate == null)
            {
                return NotFound("Todo not found");
            }

            return Ok(todoToDeactivate);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Todo todo)
        {
            var todoToUpdate = await _todosService.Update(todo);

            if (todoToUpdate == null)
            {
                return NotFound("Todo not found");
            }

            return Ok(todoToUpdate);
        }

    }

}
