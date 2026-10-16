using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TODOListSolutionApi.Dtos;
using TODOListSolutionApi.Services;

namespace TODOListSolutionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskServices _services) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<TaskResponse>>> Tasks(int pageNum)
        {
            var response = await _services.GetTasks();
            response = response?.Skip(5*pageNum)?.ToList();
            return response == null ? NotFound() : Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponse>> GetTask(Guid id)
        {
            var response = await _services.GetTask(id);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskResponse>> Update(Guid id, TaskRequest taskRequest)
        {
            var response = await _services.UpdateTask(id, taskRequest);
            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _services.Deletetask(id);
            return response == 0 ? NotFound() : Ok();
        }
    }
}
