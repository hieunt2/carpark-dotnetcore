namespace CarPark.Service.Dto
{
    public class BaseUserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDto : BaseUserDto
    {             
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
    }
}
