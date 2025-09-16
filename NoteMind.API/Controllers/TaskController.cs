using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteMind.API.Models;
using NoteMind.BLL.Dtos;
using NoteMind.BLL.Services.Interfaces;
using TaskStatus = NoteMind.BLL.Enums.TaskStatus;

namespace NoteMind.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : BaseController<TaskController>
    {
        private readonly ITaskService _taskService;

        public TaskController(IMapper mapper, ILogger<TaskController> logger, ITaskService taskService)
            : base(mapper, logger)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Отримати список завдань (можна фільтрувати по статусу).
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(int skip, int take, TaskStatus? status = null)
        {
            return Ok(await _taskService.GetAll(skip, take, (int?)status));
        }

        /// <summary>
        /// Отримати завдання по Id
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var task = await _taskService.GetByIdAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        /// <summary>
        /// Створити завдання
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskRequestModel dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return BadRequest("Title is required");

            var created = await _taskService.Create(_mapper.Map<TaskDto>(dto));
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Оновити завдання
        /// </summary>
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] TaskRequestModel dto)
        {
            var updated = await _taskService.Update(id, _mapper.Map<TaskRequestDto>(dto));
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        /// <summary>
        /// Видалити завдання
        /// </summary>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _taskService.Delete(id);

            return NoContent();
        }
    }
}
