using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
    public class PasswordForgotRequest:BaseApiRequest
    {
        public string Email { get; set; }
    }
}
