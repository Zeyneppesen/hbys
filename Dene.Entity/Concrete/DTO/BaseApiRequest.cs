﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.DTO
{
    public class BaseApiRequest
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public long UserId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public long RoleId { get; set; }
    }
}
