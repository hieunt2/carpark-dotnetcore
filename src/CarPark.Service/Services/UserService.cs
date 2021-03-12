using AutoMapper;
using System;
using System.Threading.Tasks;
using CarPark.Common;
using CarPark.Service.Dto;
using CarPark.Data.Repository;
using CarPark.Data.Model;

namespace CarPark.Service.Services
{
    public interface IUserService
    {
        Task<UserDto> Registration(UserDto model);
        Task<UserDto> GetUserByLogin(BaseUserDto model);
        Task<UserDto> GetUserByEmail(string email);
    }

    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Registration(UserDto model)
        {
            var existingUser = await _userRepository.Get(x => x.Email == model.Email);
            if (existingUser != null) throw new Exception(Constants.Users.UserExisted);

            var data = _mapper.Map<User>(model);
            var result = await _userRepository.Add(data);

            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> GetUserByLogin(BaseUserDto model) => _mapper.Map<UserDto>(await _userRepository.Get(x => x.Email == model.Email && x.Password == model.Password));        

        public async Task<UserDto> GetUserByEmail(string email) => _mapper.Map<UserDto>(await _userRepository.Get(x => x.Email == email));        
    }
}
