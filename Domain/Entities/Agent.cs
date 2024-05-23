using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Agent:BaseEntity
    {
      
        public string AgentName { get; set; }=string.Empty;
        public string AgentMail { get; set; }= string.Empty;    
        public string AgentPhoneNumber { get; set; } = string.Empty;
        public virtual ICollection<Property> Properties { get; set;}
    }
}
