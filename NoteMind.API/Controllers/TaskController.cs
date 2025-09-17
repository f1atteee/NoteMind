using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteMind.API.Models;
using NoteMind.BLL.Dtos;
using NoteMind.BLL.Services.Interfaces;
using TaskStatus = NoteMind.BLL.Enums.TaskStatus;

namespace NoteMind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        private readonly ILogger<TaskController> _logger;

        public TaskController(IMapper mapper, ILogger<TaskController> logger, ITaskService taskService)
        {
            _mapper = mapper;
            _logger = logger;
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(TaskStatus? status = null)
            => Ok(await _taskService.GetAll((int?)status));

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskRequestModel dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return BadRequest("Title is required");

            var created = await _taskService.Create(_mapper.Map<TaskDto>(dto));
            return Ok(created);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] TaskRequestModel dto)
        {
            var updated = await _taskService.Update(id, _mapper.Map<TaskRequestDto>(dto));
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _taskService.Delete(id);
            return NoContent();
        }
    }
}