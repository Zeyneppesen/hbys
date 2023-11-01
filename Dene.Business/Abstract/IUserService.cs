using Dene.Entity.Concrete.DTO;
using Dene.Entity.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Business.Abstract
{
    public interface IUserService
    {
        GetUserResponse GetUser(GetUserRequest request);
        UserRegisterResponse Register(UserRegisterRequest request);
        User Get(string email);
        User Get(long id);
        MailVerifyResponse Verify(MailVerifyRequest request);

    }
}
