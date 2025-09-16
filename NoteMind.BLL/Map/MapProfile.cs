using AutoMapper;
using NoteMind.BLL.Dtos;
using NoteMind.BLL.Enums;
using NoteMind.DAL.Models;
using TaskStatus = NoteMind.BLL.Enums.TaskStatus;

namespace NoteMind.BLL.Map
{
    internal class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TaskEntity, TaskDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TaskStatus)src.Status))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority)src.Priority));

            CreateMap<TaskDto, TaskEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (int)src.Priority));

            CreateMap<TaskRequestDto, TaskDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TaskStatus)src.Status))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority)src.Priority))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<TaskRequestDto, TaskEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TaskStatus)src.Status))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (TaskPriority)src.Priority))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
        }
    }
}
