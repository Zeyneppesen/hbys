using Dene.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.Models
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Surname")]
        public string? Surname { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Ip")]
        public string Ip { get; set; }
        [Column("EmailConfirmed")]
        public bool EmailConfirmed { get; set; }
        [Column("Phone")]
        public string Phone { get; set; }
        [Column("RoleId")]
        public long RoleId { get; set; }

        [NotMapped]
        public bool Remember { get; set; }
    }
}