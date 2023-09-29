using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
    public class PasswordResetRequest:BaseApiRequest
    {

        public string Guid { get; set; }
        public string Password { get; set; }
       // public string ConfirmPassword { get; set; }
    }
}
