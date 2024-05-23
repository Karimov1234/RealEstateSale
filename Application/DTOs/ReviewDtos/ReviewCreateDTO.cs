using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ReviewDtos
{
    public class ReviewCreateDTO
    {
        public string UserId { get; set; }
        public int PropertyId { get; set; }
        public string ReviewText { get; set; }
        public int Point { get; set; }
    }
}
