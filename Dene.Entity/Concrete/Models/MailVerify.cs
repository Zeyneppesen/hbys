#region Assembly Agriculture.Entity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// C:\Users\asus\source\repos\Agriculture\Agriculture.Entity\obj\Debug\net6.0\ref\Agriculture.Entity.dll
#endregion
using Dene.Core.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dene.Entity.Concrete.Models
{
    [Table("MailVerify")]
    public class MailVerify:BaseEntity
    {

        
            [Column("UserId")]
            public long UserId { get; set; }

            
        
    }
}
