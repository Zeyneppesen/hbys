
using Dene.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dene.Entity.Concrete.Models
{
    [Table("MailVerify")]
    public class MailVerify:BaseEntity
    {

        [Column("Id")]
        public long Id { get; set; }
        [Column("UserId")]
        public long UserId { get; set; }

        [Column("Status")]
        public bool Status { get; set; }

    }
}
