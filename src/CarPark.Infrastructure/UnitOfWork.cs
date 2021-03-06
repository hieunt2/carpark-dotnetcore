using CarPark.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace CarPark.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        Task CreateTransaction();
        Task Commit();
        Task Rollback();
        Task SaveChange();
    }
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly CarParkDbContext _dbContext;
        private IDbContextTransaction _transaction;
        public UnitOfWork(IDbContextFactory<CarParkDbContext> dbContextFactory)
        {
            if (_dbContext == null)
            {
                _dbContext = dbContextFactory.CreateDbContext();
            }
        }

        public IUserRepository UserRepository => new UserRepository(_dbContext);

        #region Transaction
        public async Task CreateTransaction()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public async Task SaveChange()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}