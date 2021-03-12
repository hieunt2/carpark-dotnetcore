using Application.Tests.Mock;
using CarPark.Data.Model;
using CarPark.Data.Repository;
using CarPark.Service.Dto;
using CarPark.Service.Services;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.Users
{
    public class UsersControllerTests
    {
        public UsersControllerTests()
        {

        }
        
        [Fact]
        public async Task UsersController_Registration_ShouldRegisterValidUser()
        {
            // Arrange
            var repo = Substitute.For<IUserRepository>();
            var service = new UserService(repo, Mock.Mapper);
            var model = new UserDto
            {
                FirstName = "Hieu",
                LastName = "Ngo",
                Email = "hieunt2@smartosc.com",
                ContactNumber = "0123456789",
                Password = "123456"
            };

            // Act
            var result = await service.Registration(model);

            // Assert
            await repo.Received(1).Add(Arg.Is<User>(x => x.Email == model.Email));
        }
    }
}
