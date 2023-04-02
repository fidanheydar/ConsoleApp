using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFoodApp.Core.Repositories
{
    public interface IRepository<T>
    {
        public Task AddAsync(T model);
        public Task RemoveAsync(T model);
        public Task <List<T>> GetAllAsync();
        public Task UpdateAsync(T model);   
        public  Task<T> GetAsync(Func<T, bool> expression);
    }
}
