using AutoMapper;
using Todo.Interface.Dtos;
using Model = Todo.Interface.DataModels;


namespace Todo.Implementation.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateTodoReqeustDto, Model.Todo>();
        }
    }
}
