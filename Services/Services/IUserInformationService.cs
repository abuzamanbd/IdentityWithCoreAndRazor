using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Repositories.Models;
using Repositories.UnitOfWork;

namespace Services.Services
{
    public interface IUserInformationService
    {
        Task<AspNetUser> GetUser(string email);
    }

    public class UserInformationService : IUserInformationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserInformationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AspNetUser> GetUser(string email)
        {
            return await _unitOfWork.UserInformationRepository.FindSingleAsync(x => x.Email == email);
        }
    }
}
