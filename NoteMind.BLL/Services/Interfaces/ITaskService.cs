using NoteMind.BLL.Dtos;

namespace NoteMind.BLL.Services.Interfaces
{
    public interface ITaskService : IService<TaskDto>
    {
        Task<IEnumerable<TaskDto>> GetAll(int? status);
        Task<IEnumerable<TaskDto>> GetByStatusAsync(int status);
        Task<IEnumerable<TaskDto>> GetActiveAsync();
        Task<IEnumerable<TaskDto>> GetCompletedAsync();

        Task<TaskDto> Update(long id, TaskRequestDto dto);
    }
}