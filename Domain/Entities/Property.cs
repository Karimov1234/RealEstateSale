using Domain.Entities.Common;
using Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Property:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public int Price { get; set; }
        public string Address { get; set; }
        public int CountRooms { get; set; }
        public int CountBathRooms { get; set; }
        public int CountSquareFeet { get; set; }
        public string Status { get; set; }
        public int AgentId { get; set; }
        public virtual Agent Agent { get; set; }
        public int CategoryId {  get; set; }
        public  Category Category { get; set; }
        public int OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public int RegionOfCityId {  get; set; }    
        public virtual RegionOfCity RegionOfCity { get; set; }  
        public virtual ICollection<Review> Reviews { get; set;}
        public virtual ICollection<Image> Images { get; set; }

    }
}
