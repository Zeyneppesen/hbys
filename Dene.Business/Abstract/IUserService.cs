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
        GetUserResponse GetUser(GetUserRequest request);
      
    }
}
