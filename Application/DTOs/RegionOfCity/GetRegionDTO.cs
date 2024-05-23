using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.RegionOfCity
{
    public class GetRegionDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
