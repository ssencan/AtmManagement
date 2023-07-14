﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace AtmManagement.Api.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        Task CommitAsync();
        // other methods...
    }

}
