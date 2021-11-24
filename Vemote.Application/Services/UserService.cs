using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vemote.Application.DTOs;
using Vemote.Application.IServices;
using Vemote.Domain.Entities;
using Vemote.Domain.Infrastructure.Persistence.UoW;

namespace Vemote.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<bool> ChangeUserAddress()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeUserInfo(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateUser(UserDTO userdto)
        {
            Users user = _mapper.Map<Users>(userdto);
            var CanCreate = await CheckUserID(user.ID);
            if (CanCreate)
            {
                var result = await _unitOfWork.Users.Add(user);
                return result;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> CheckUserID(string ID)
        {
            var res = await _unitOfWork.Users.CheckByID(ID);
            if (res==true)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public async Task<UserDTO> GetUserByID(string ID)
        {
            Users user = await _unitOfWork.Users.GetByID(ID);
            if (user != null)
            {
                UserDTO userDto = _mapper.Map<Users, UserDTO>(user);
                return userDto;
            }
            return new UserDTO();

        }
    }
}
