using Dene.Core.Abstract;
using Dene.Core.Data.Ef;
using Dene.Entity.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Dene.Data.Abstract
{
    public interface IMailVerifyRepository : IEntityRepository<MailVerify>
    {
    }
}
