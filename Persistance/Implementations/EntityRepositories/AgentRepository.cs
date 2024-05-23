using Application.Abstractions.IEntityRepositories;
using Domain.Entities;
using Persistance.Implementations.Repositories;

namespace Persistance.Implementations.EntityRepositories
{
    public class AgentRepository : GenericRepository<Agent>, IAgentRepository
    {
      
        public AgentRepository(AppDbContext context) : base(context)
        {
            
        }

    }
}
