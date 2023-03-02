using Api_ToDoLis.Data.Dto.ToDoList;
using Api_ToDoLis.Models;
using AutoMapper;

namespace Api_ToDoLis.Profiles
{
    public class ToDoListProfile : Profile
    {
        public ToDoListProfile()
        {
            CreateMap<CreateToDoList, ToDoList>()
                .ForMember(c => c.DataInclusao, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<ToDoList, ReadToDoList>();
            CreateMap<UpdateToDoList, ToDoList>();
        }
    }
}
