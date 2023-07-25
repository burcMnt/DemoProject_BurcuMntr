using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<UserLoginDto> Login(UserLoginDto user);
        Task<UserSignUpDto> SignUp(UserSignUpDto user);
    }
}
