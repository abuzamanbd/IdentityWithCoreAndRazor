using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Context;
using Repositories.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Repositories
{

    public interface IUserInformationRepositories : IRepositoryBase<AspNetUser>
    {

    }

    public class UserInformationRepositories : RepositoryBase<AspNetUser>, IUserInformationRepositories
    {
        public UserInformationRepositories(ApplicationDbContext context) : base(context)
        {
        }
    }
}
