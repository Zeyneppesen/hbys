using Dene.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dene.Entity.Concrete.Models
{
    [Table("Patients")]
    public class Patient : BaseEntity
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("LastName")]
        public string LastName { get; set; }
        [Column("TcNo")]
        public string TcNo { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }
        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }
        [Column("Place")]
        public string Place { get; set; }

        [Column("BloodType")]
        public string BloodType { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("Eposta")]
        public string Eposta { get; set; }
        [Column("Adress")]
        public string Adress{ get; set; }
        [Column("PoliClinic")]
        public string PoliClinic { get; set; }
        [Column("InDate")]
        public DateTime InDate { get; set; }
        [Column("OutDate")]
        public DateTime OutDate { get; set; }
        
        //[Column("AgeIn")]
        //public DateTime AgeIn { get; set; }
    }
}
