using System;
using System.Collections.Generic;
using System.Text;

namespace Application.interfaces
{
    public interface IUnitOfWork
    {
        IStarshipRepository Starships { get; }
        void Save();
    }
}
