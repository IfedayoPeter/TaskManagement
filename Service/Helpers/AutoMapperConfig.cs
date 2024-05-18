using AutoMapper;
using TaskManagement.Domain.DTOS;
using TaskManagement.Domain.Model;

namespace TaskManagement.Service.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TaskModel, TaskDTO>()
                .ReverseMap();
        }
    }
}