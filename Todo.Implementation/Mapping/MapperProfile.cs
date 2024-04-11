using Model = Todo.Interface.DataModels;
using Todo.Interface.Dtos;
using AutoMapper;


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
