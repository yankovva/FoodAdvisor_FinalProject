using Microsoft.EntityFrameworkCore;
namespace FoodAdvisor.Data.Repository
{
	public class Repository<TType, TId> : IRepository<TType, TId> where TType : class
	{
		private readonly FoodAdvisorDbContext dbContext;
		private readonly DbSet<TType> dbSet;
		public Repository(FoodAdvisorDbContext dbContext, DbSet<TType> dbSet)
		{
			this.dbContext = dbContext;
			this.dbSet = this.dbContext.Set<TType>();

		}
		public void Add(TType item)
		{
			dbSet.Add(item);
			dbContext.SaveChanges();
		}

		public async Task AddAsync(TType item)
		{
			dbSet.Add(item);
			await dbContext.SaveChangesAsync();
		}

		public bool Delete(TId id)
		{
			TType entity = GetById(id);
			if (entity == null)
			{
				return false;
			}
			dbSet.Remove(entity);
			dbContext.SaveChanges();

			return true;
		}

		public async Task<bool> DeleteAsync(TId id)
		{
			TType entity = await GetByIdAsync(id);
			if (entity == null)
			{
				return false;
			}
			dbSet.Remove(entity);
			await dbContext.SaveChangesAsync();

			return true;
		}

		public IEnumerable<TType> GetAll()
		{
			return dbSet.ToArray();
		}

		public async Task<IEnumerable<TType>> GetAllAsync()
		{
			return await dbSet.ToArrayAsync();
		}

		public IEnumerable<TType> GetAllAttached()
		{
			return dbSet.AsQueryable();
		}

		public TType GetById(TId id)
		{
			TType? entity = this.dbSet
			   .Find(id);

			return entity;
		}

		public async Task<TType> GetByIdAsync(TId id)
		{
			TType? entity = await this.dbSet
						   .FindAsync(id);

			return entity;
		}

		public bool Update(TType item)
		{
			try
			{
				dbSet.Attach(item);
				dbContext.Entry(item)
					.State = EntityState.Modified;
				dbContext.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public async Task<bool> UpdateAsync(TType item)
		{
			try
			{
				dbSet.Attach(item);
				dbContext.Entry(item)
					.State = EntityState.Modified;
				await dbContext.SaveChangesAsync();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
	}
}
