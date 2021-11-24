using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Application.DTOs;

namespace Vemote.Application.IServices
{
    public interface IUserService
    {
        public Task<UserDTO> GetUserByID(string ID);
        public Task<bool> CreateUser(UserDTO user);
        public Task<bool> ChangeUserInfo(UserDTO user);
        public Task<bool> ChangeUserAddress();
    }
}
