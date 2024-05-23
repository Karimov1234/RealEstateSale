using Domain.Entities.Common;
using Domain.Entities.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Review:BaseEntity
    {
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
        public string ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Point { get; set; }
    }
}
