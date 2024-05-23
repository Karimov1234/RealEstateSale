﻿using Application.Abstractions.IEntityRepositories;
using Domain.Entities;
using Persistance.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Implementations.EntityRepositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {

        public PropertyRepository(AppDbContext context) : base(context)
        {

        }

    
    }
}
