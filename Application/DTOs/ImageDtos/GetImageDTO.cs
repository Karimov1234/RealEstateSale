using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ImageDtos
{
    public class GetImageDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PropertyId { get; set; }
    }
}
