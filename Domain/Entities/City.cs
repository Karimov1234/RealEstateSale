using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City:BaseEntity
    {
        public string CityName { get; set; } = string.Empty;
        public string Country { get; set; }= string.Empty;  
        public virtual ICollection<RegionOfCity> RegionOfCities { get; set; }

    }
}
