using CarPark.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
    }

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContext _context) : base(_context)
        {

        }
    }
}
