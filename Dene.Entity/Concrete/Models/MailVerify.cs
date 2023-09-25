using Dene.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.Models
{
    [Table("MailVerify")]
    public class MailVerify:BaseEntity
    {

        
            [Column("UserId")]
            public long UserId { get; set; }

            [Column("Guid")]
            public string Guid { get; set; }
        
    }
}
