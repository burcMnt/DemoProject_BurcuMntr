using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repository;
using System;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IAsyncRepository<User> _userRepository;
        public UserRepository(IAsyncRepository<User> genericRepository, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _userRepository = genericRepository;
        }

        public Task<UserLoginDto> Login(UserLoginDto model)
        {

            UserLoginDto result = new();
            User user = new();

            user = _dbContext.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                {
                    result.IsSuccess = true;
                    result.UserName= model.UserName;
                    result.ResultMessage = "success";

                }
                else
                {
                    result.IsSuccess = false;
                    result.ResultMessage = "Kullanıcı Adı Veya Şifre Geçersiz.";
                }
            }
            else
            {
                result.IsSuccess = false;
                result.ResultMessage = " Bu bilgilerde kullanıcı bulunmamaktadır. Kayıt yapmak için kayıt sayfasına gidiniz.";
            }

            return Task.FromResult(result);

        }

        public Task<UserSignUpDto> SignUp(UserSignUpDto model)
        {
            User userData = new();
            UserSignUpDto result = new UserSignUpDto();

            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == model.UserName || x.Email == model.Email);

            if (user != null)
            {
                result.ResultMessage = "Bu Kullanıcı Bilgilerine Ait Sistemde Kayıtlı Kullanıcı Bulunmaktadır .";
                result.IsSuccess = false;
            }
            else
            {
                userData.UserName = model.UserName;
                userData.Email = model.Email;
                userData.Password = BCrypt.Net.BCrypt.HashPassword(model.Password, SaltRevision.Revision2A);

                var record = _userRepository.AddAsync(userData);

                if (record.Id != null)
                {
                    result.IsSuccess = true;
                    result.ResultMessage = "success";
                }
                else
                {
                    result.IsSuccess = false;
                    result.ResultMessage = "Kayıt sırasında bir hata oluştu.";
                }

            }

            return Task.FromResult(result);
        }
    }
}
