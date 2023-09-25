using Dene.Entity.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Business.Abstract
{
    public interface IUserService
    {
        ChangePasswordResponse ChangePassword(ChangePasswordRequest request);
        UserGetInfoResponse GetInfo(UserGetInfoRequest request);
        UserLoginResponse Login(UserLoginRequest userLoginRequest);
        PasswordForgotResponse PasswordForgot(PasswordForgotRequest request);
        PasswordResetResponse PasswordReset(PasswordResetRequest request);
        UserPutInfoResponse PutInfo(UserPutInfoRequest request);
        UserRegisterResponse Register(UserRegisterRequest userRegisterRequest);
        MailVerifyResponse Verify(MailVerifyRequest request);
    }
}
