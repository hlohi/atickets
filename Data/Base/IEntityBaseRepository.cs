using atickets.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atickets.Data
{
    public interface IEntityBaseRepository<T> where T: class,IEntityBase, new()
    {
        // get all the actors from the database
        Task<IEnumerable<T>> GetAllAsync(); // if we want to make an async implemtation we add Tack<>
        // a method to return a single actor
        Task<T> GetByIdAsync(int id);
        // a method to add data to the database
        Task AddAsync(T actor);
        //update data to the database
        Task UpdateAsync(int id,T entity);

        Task DeleteAsync(int id);
    }
}
