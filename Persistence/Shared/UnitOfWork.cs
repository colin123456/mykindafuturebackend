using System;
using System.Collections.Generic;
using System.Text;
using Application.interfaces;

namespace Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StarshipDbContext _dbContext;

        public UnitOfWork(StarshipDbContext dbContext)
        {
            _dbContext = dbContext;
            Starships =  new StarshipRepository(_dbContext); 
        }
        public IStarshipRepository Starships { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
