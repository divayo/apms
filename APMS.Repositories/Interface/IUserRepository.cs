using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using APMS.Data.Entities;

namespace APMS.Repositories.Interface
{
    public interface IUserRepository : IWriteRepository<User>, IReadRepository<User>
    {
        
    }
}