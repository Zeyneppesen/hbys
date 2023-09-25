using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
   public class UserGetInfoResponse:BaseApiResponse
    {
        public long UserId { get; set; }
        public string? Name { get; set; }

        public string? Surname { get; set; }
        public string? Phone { get; set; }
    }
}
