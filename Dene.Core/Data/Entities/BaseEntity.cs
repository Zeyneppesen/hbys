using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Core.Data.Entities
{
    public class BaseEntity:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }


        [System.Text.Json.Serialization.JsonIgnore]
        [Column("Name")]
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Column("LastName")]
        public string LastName { get; set; }
    }
}
