using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image:BaseEntity
    {
        public string Url { get; set; } = string.Empty;
        public int PropertyId {  get; set; }
        public virtual Property Property { get; set; }
    }
}
