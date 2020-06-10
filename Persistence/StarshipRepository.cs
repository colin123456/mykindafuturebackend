using System;
using System.Collections.Generic;
using System.Text;
using Application.interfaces;
using Domain.Starships;
using Persistence.Shared;

namespace Persistence
{
    public class StarshipRepository: Repository<StarShip>, IStarshipRepository
    {
        private readonly StarshipDbContext _dbContext;
        public StarshipRepository(StarshipDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
