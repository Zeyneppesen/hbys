using Dene.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dene.Entity.Concrete.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Surname")]

        public string Surname { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        
        [Column("Phone")]
        public string Phone { get; set; }
       
        [Column("Status")]
        public bool Status { get; set; }
        [Column("RoleId")]
        public long RoleId { get; set; }



        //[NotMapped]
        //public bool Remember { get; set; }
    }
}