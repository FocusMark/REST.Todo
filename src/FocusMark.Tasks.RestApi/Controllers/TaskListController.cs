using FocusMark.Tasks.Application.TasksLists.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FocusMark.Tasks.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TaskListController : ControllerBase
    {
        public TaskListController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public IMediator Mediator { get; }

        // GET: api/<TaskListController>
        [HttpGet]
        public Task<IActionResult> Get()
        {
            return Task.FromResult((IActionResult)Ok());
        }

        // GET api/<TaskListController>/5
        [HttpGet("{id}")]
        public Task<IActionResult> Get(Guid id)
        {
            return Task.FromResult((IActionResult)Ok());
        }

        // POST api/<TaskListController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTaskListCommand command)
        {
            Guid id = await this.Mediator.Send(command);
            return CreatedAtAction(nameof(Post), new { id });
        }

        // PUT api/<TaskListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
