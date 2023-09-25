using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
    public class MailVerifyRequest : BaseApiRequest
    {
        public string Guid { get; set; }
    }
}
