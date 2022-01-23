using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        Task SaveAsync();

    }
}
