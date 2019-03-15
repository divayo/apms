using APMS.Data.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APMS.Repositories.Interface
{
    public interface IReadRepository<T> where T : IBaseEntity
    {
        /// <summary>
        ///     Get entity by id
        /// </summary>
        /// <param name="id">id of the entity</param>
        /// <returns></returns>
        Task<T> GetById(Guid id);

        /// <summary>
        ///     Get all entities of type <see cref="T"/>
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        ///     Get filtered entities of type <see cref="T"/>
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetFiltered(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    }
}
