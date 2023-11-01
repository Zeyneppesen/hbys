using Dene.Business.Abstract;
using Dene.Data.Abstract;
using Dene.Data.Concrete.Ef;
using Dene.Entity.Concrete.DTO;
using Dene.Entity.Concrete.Models;
using Dene.Entity.Concrete.Validators;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Presentation;
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
       

        public UserService(IUserRepository userRepository, IMailVerifyRepository mailVerifyRepository)
        {
            _userRepository = userRepository;
            _mailVerifyRepository = mailVerifyRepository;

        }

        public User Get(string email)
        {
            return _userRepository.Get(p => p.Email == email);
        }

        public User Get(long id)
        {
            return _userRepository.Get(p => p.Id == id);
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
                    model.Ip= user.Ip;
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
                var validator = new RegisterValidator();
                var validatorResult = validator.Validate(request);

                if (!validatorResult.IsValid)
                {
                    foreach (var err in validatorResult.Errors)
                    {
                        response.Errors.Add(err.ErrorMessage);
                    }
                    response.Code = "400";
                    response.Message = "bir hata alındı.";
                    response.Errors.Add("Doğrulama hatası");
                    return response;
                }
                var user = Get(request.Email);
                if (user != null)
                {
                    return GetRegisterResponse("400", "Bu email adresine kayıtlı kullanıcı bulunmaktadır.");
                }


                var mailUser = _userRepository.Add(SetUserDefualtData(request));
                MailVerify mailVerify = new MailVerify();
                mailVerify.UserId = mailUser.Id;
               
                _mailVerifyRepository.Add(mailVerify);
             //   SendVerifyEmail(mailUser.Email, mailVerify.Guid);

                return GetRegisterResponse("200", "Kullanıcı kaydı başarılı.");
            }
            catch (Exception e)
            {

                response.Code = "400";
                response.Message = e + " Hatası";
                return response;
            }
        }

        public UserRegisterResponse GetRegisterResponse(string code, string message)
        {
            var userRegisterResponse = new UserRegisterResponse();
            userRegisterResponse.Code = code;

            if (code.Equals("400"))
            {
                userRegisterResponse.Errors.Add(message);
            }
            else
            {
                userRegisterResponse.Message = message;
            }
            return userRegisterResponse;
        }

        public User SetUserDefualtData(UserRegisterRequest request)
        {
            var user = new User();
            user.Id=request.Id;
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Email = request.Email;
            user.Password = request.Password;
            user.Phone = request.Phone;
            user.RoleId = request.RoleId;           
            user.Ip = request.Ip;
            user.Status = true;
            return user;
        }

        public MailVerify GetIp(string ip)
        {
            return _mailVerifyRepository.Get(p => p.Ip == ip);
        }
        public MailVerifyResponse Verify(MailVerifyRequest request)
        {
            var mailVerifyResponse = new MailVerifyResponse();
             var verify = GetIp(request.Ip);
            if (verify == null)
            {
                mailVerifyResponse.Code = "400";
                mailVerifyResponse.Errors.Add("Doğrulama işleminde hata meydana geldi.");
                return mailVerifyResponse;
            }

            if (verify.Status)
            {
                mailVerifyResponse.Code = "200";
                mailVerifyResponse.Message = "Mail adresiniz önceden doğrulanmıştır.";
                return mailVerifyResponse;
            }

            //if (verify.DeletedDate <= DateTime.Now)
            //{
            //    mailVerifyResponse.Code = "400";
            //    mailVerifyResponse.Errors.Add("Doğrulama süresi geçmiştir.");
            //    return mailVerifyResponse;
            //}

            var user = Get(verify.UserId);
            if (user == null)
            {
                mailVerifyResponse.Code = "400";
                mailVerifyResponse.Errors.Add("Kullanıcı bulunamadı.");
                return mailVerifyResponse;
            }

            //user.EmailConfirmed = true;
            _userRepository.Update(user);

           // verify.ModifiedDate = DateTime.Now;
            verify.Status = true;
            _mailVerifyRepository.Update(verify);

            mailVerifyResponse.Code = "200";
            mailVerifyResponse.Message = "Email doğrulama başarıyla yapıldı. Giriş yapabilirsiniz.";
            return mailVerifyResponse;
        }
    }
    
}