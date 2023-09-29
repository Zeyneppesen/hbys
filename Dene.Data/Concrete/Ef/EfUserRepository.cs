using Dene.Core.Data.Ef;
using Dene.Data.Abstract;
using Dene.Entity.Concrete.Models;
using Microsoft.EntityFrameworkCore;



namespace Dene.Data.Concrete.Ef
{
    public class EfUserRepository : EfEntityRepository<User, PatientDbContext>,IUserRepository
    {
  
    }
}
