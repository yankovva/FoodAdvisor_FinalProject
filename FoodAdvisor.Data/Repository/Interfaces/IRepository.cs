using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodAdvisor.Data.Repository.Interfaces
{
    public interface IRepository<TType, TId>
    {
        TType GetById(TId id);
        Task<TType> GetByIdAsync(TId id);

        IEnumerable<TType> GetAll();
        Task<IEnumerable<TType>> GetAllAsync();
        IQueryable<TType> GetAllAttached();

        void Add(TType item);
        Task AddAsync(TType item);

        Task SaveChangesAsync();

        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);
        Task DeleteAsync(TType entity);

		bool Update(TType item);
        Task<bool> UpdateAsync(TType item);

    }
}
