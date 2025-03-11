using AutoMapper;
using Core.Application.CasosUso.Produtos.Commands.Users.Commands.CreateUser;


namespace Core.Application.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, CreateUserCommand>();
            CreateMap<CreateUserDTO, CreateUserCommand>();
        }
    }
}
