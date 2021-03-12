using AutoMapper;
using CarPark.Data.Model;
using CarPark.Service.Dto;

namespace CarPark.Service.Mapper
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
