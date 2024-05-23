using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RegionOfCity
{
    public class CreateUpdateRegionDTO
    {
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
