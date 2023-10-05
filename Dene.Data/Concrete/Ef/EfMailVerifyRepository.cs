using Dene.Core.Data.Ef;
using Dene.Core.Data.Ef;
using Dene.Data.Abstract;
using Dene.Entity.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Data.Concrete.Ef
{
    public class EfMailVerifyRepository:EfEntityRepository<MailVerify, PatientDbContext>,IMailVerifyRepository
    {
    }
}
