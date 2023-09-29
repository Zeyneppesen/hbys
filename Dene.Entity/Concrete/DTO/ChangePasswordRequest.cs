using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
public class ChangePasswordRequest:BaseApiRequest
    {
        //public string OldPassword { get; set; }
        //public string NewPassword { get; set; }
        //public string ConfirmPassword { get; set; }
        //public long RoleId { get; set; }
        public long UserId { get; set; }
    }
}
