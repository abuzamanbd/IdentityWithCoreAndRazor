using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Context;
using Repositories.Repositories;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> SaveCompletedAsync();
        IUserInformationRepositories UserInformationRepository { get; }
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private IUserInformationRepositories _userInformationRepositories;

        public IUserInformationRepositories UserInformationRepository =>
            _userInformationRepositories ??= new UserInformationRepositories(_context);


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public async Task<bool> SaveCompletedAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
