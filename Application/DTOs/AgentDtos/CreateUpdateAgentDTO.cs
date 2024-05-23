using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.AgentDtos
{
    public class CreateUpdateAgentDTO
    {

        public string AgentName { get; set; }
        public string AgentMail { get; set; }
        public string AgentPhoneNumber { get; set; }
    }
}
