using Api_ToDoLis.Data.Dto.TipoLista;
using Api_ToDoLis.Models;
using AutoMapper;

namespace Api_ToDoLis.Profiles
{
    public class TipoListaProfile : Profile
    {
        public TipoListaProfile()
        {
            CreateMap<CreateTipoLista, TipoLista>()
                .ForMember(o => o.Ativo, opt => opt.MapFrom(src => true));
            CreateMap<TipoLista, ReadTipoLista>();
            CreateMap<UpdateTipoLista, TipoLista>();
        }
    }
}
