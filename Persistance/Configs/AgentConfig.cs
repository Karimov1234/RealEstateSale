using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configs
{
    public class AgentConfig : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            builder.Property(x => x.AgentName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.AgentMail).IsRequired();
            builder.Property(x => x.AgentPhoneNumber).IsRequired();

        }
    
    }
}
