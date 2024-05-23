using Domain.Entities.Identities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.PropertyDtos
{
    public class GetPropertyDTO
    {
        public int Id { get; set; }
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
        public int OwnerId { get; set; }
        public int RegionOfCityId { get; set; }
        public int CategoryId { get; set; }

    }
}
