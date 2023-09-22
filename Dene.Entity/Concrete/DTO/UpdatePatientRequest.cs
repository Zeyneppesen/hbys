using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
    public class UpdatePatientRequest:BaseApiRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Place { get; set; }
        public string BloodType { get; set; }
        public string Phone { get; set; }
        public string Eposta { get; set; }
        public string Adress { get; set; }
        public string PoliClinic { get; set; }
        public DateTime InDate { get; set; }
        public DateTime OutDate { get; set; }
    }
}
