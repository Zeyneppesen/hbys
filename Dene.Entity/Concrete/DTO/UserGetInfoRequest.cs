using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
    public class UserGetInfoRequest : BaseApiRequest
    {
        public long UserId { get; set; }
    }
}
