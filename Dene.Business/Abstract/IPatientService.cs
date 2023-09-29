using Dene.Entity.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Business.Abstract
{
   public interface IPatientService
    {
     //    GetTotalAgeResponse GetTotalAge(GetTotalAgeRequest request);
         GetNameWithZResponse GetNameWithZ(GetNameWithZRequest request);
         GetManOverTewFourResponse GetManOverTewFour(GetManOverTewFourRequest request);
         GetManPatientResponse GetManList(GetManPatientRequest request);
         GetWomenPatientResponse GetWomenList(GetWomenPatientRequest request);
         GetPatientResponse GetList(GetPatientRequest request);
         AddPatientResponse AddPatient(AddPatientRequest request);
         UpdatePatientResponse UpdatePatient(UpdatePatientRequest request);
         DeletePatientResponse DeletePatient(DeletePatientRequest request);
    }
}
