using Dene.Business.Abstract;
using Dene.Data.Abstract;
using Dene.Entity.Concrete.DTO;
using Dene.Entity.Concrete.Models;
using Dene.Entity.Concrete.Validators;
using DocumentFormat.OpenXml.EMMA;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailVerifyRepository _mailVerifyRepository;

    
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
          //  _mailVerifyRepository = mailVerifyRepository;

        }

        public GetUserResponse GetUser(GetUserRequest request)
        {
            var response = new GetUserResponse();
            try
            {
                var users = _userRepository.GetList();
                List<UserModel> usersModels = new List<UserModel>();

                foreach (var user in users)
                {
                    var model = new UserModel();

                    model.Id = user.Id;
                    model.Name = user.Name;
                    model.Surname = user.Surname;
                    model.Email = user.Email;
                    model.Password = user.Password;
                    model.Phone = user.Phone;
                    model.Status = user.Status;
                    model.RoleId= user.RoleId;
                    usersModels.Add(model);

                }
                response.UserModels = usersModels;
                return response;
            }
            catch (Exception e)
            {
                response.Errors.Add("Bir hata ile karşılaşıldı. " + e.Message);
                response.Code = "400";
                return response;
            }
        }

        public UserRegisterResponse Register(UserRegisterRequest request)
        {
            var response = new UserRegisterResponse();
            try
            {
              
                 User user=new User();
                _userRepository.Add(user);
               

                return response;
            }
            catch (Exception e)
            {

                response.Code = "400";
                response.Message = e + " Hatası";
                return response;
            }
        }
    }
}