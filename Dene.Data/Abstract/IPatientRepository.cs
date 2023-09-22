using Dene.Core.Abstract;
using Dene.Entity.Concrete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Data.Abstract
{
    public interface IPatientRepository : IEntityRepository<Patient>
    {
    }
}
