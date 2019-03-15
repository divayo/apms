using APMS.Data;
using APMS.Data.Entities;
using APMS.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APMS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly APMSDbContext _dbContext;

        public UserRepository(APMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Create(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result == 1;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<User>> GetFiltered(Expression<Func<User, bool>> predicate)
        {
            return await _dbContext.Users.Where(predicate).ToListAsync();
        }

        public async Task<User> Update(User entity)
        {
            _dbContext.Users.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
