using APMS.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APMS.Repositories.Interface
{
    public interface IWriteRepository<T> where T : IBaseEntity
    {
        Task<T> Create(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(T entity);
    }
}
