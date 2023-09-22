using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
    public class GetManOverTewFourResponse:BaseApiResponse
    {
        public List<PatientModel> PatientModels { get; set; }
    }
}
