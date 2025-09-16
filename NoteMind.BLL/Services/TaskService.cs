using AutoMapper;
using NoteMind.BLL.Dtos;
using NoteMind.BLL.Services.Interfaces;
using NoteMind.DAL.Interface;
using NoteMind.DAL.Models;

namespace NoteMind.BLL.Services
{
    internal class TaskService : GenericService<TaskDto, TaskEntity>, ITaskService
    {
        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(mapper, unitOfWork)
        {}

        public async Task<IEnumerable<TaskDto>> GetAll(int skip, int take, int? status)
        {
            var tasks = await _unitOfWork.TaskRepository.GetByLimitAsync(skip, take);
            if (status != null)
                tasks = tasks.Where(x => x.Status == status).ToList();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<IEnumerable<TaskDto>> GetByStatusAsync(int status)
        {
            var tasks = await _unitOfWork.TaskRepository.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<IEnumerable<TaskDto>> GetActiveAsync()
        {
            var tasks = await _unitOfWork.TaskRepository.GetActiveAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<IEnumerable<TaskDto>> GetCompletedAsync()
        {
            var tasks = await _unitOfWork.TaskRepository.GetCompletedAsync();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> Update(long id, TaskRequestDto dto)
        {
            var existingTask = await _unitOfWork.TaskRepository.GetByIdAsync(id);
            if (existingTask == null)
                throw new KeyNotFoundException($"Task with Id {id} not found");

            // Мапимо DTO на існуючу сутність
            _mapper.Map(dto, existingTask);
            existingTask.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.TaskRepository.Update(existingTask);

            return _mapper.Map<TaskDto>(existingTask);
        }
    }
}
