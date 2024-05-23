using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RegionOfCity:BaseEntity
    {
        public string Name {  get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
