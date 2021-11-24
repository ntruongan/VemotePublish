using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Domain.Entities;

namespace Vemote.Domain.Infrastructure.Persistence.Repositories
{
    public interface IUserRepository: IGenericRepository<Users>
    {
        /*        bool CheckUserExist(User user);
                Task<bool> AddVerifyPhone(VerifyPhone verify);
                Task<User> GetById(string id);
                VerifyPhone GetVerifyPhone(string phone);
                Task<User> Login(string phone, string password);*/
        public Task<bool> CheckUserExist(string UID);
    }
}
