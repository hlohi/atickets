using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }
                                                   // make it a one line function
        // public asyn Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task AddAsync(T entity)
        {
            await  _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // almost same logic as update method
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
           
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();


        }

        // Set<T> makes it generic for all the classes
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;

            //var result = await _context.Actors.ToListAsync();
            //return result;
        }
        
       // public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id)
        // or     use a one line method 
        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return result;

         //before   //var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            //return result;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            // new class that is being used
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }
    }
}
