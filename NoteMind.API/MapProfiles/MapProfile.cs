using AutoMapper;
using NoteMind.API.Models;
using NoteMind.BLL.Dtos;

namespace NoteMind.API.MapProfiles
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<TaskRequestModel, TaskRequestDto>().ReverseMap();
        }
    }
}