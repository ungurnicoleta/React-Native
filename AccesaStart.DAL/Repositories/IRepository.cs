using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccesaStart.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task<T> Read(string key);
        Task Update(User user);
    }
}
