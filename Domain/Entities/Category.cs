﻿using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category:BaseEntity
    {

       public string Name {  get; set; }=string.Empty;
        public virtual ICollection<Property> Properties { get; set; }

    }
}
