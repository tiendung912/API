using System.Linq.Expressions;
using AutoMapper;
using dungDAL.dungContext;
using dungDDL.IRepositories;
using dungDDL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace dungDDL.Repositories
{
    public class RepositoryBase<T, TModel> : IRepositoryBase<T, TModel>, IDisposable where T : class, new() where TModel : class
    {
        private readonly IMapper _mapper;
        private readonly dungDbContext _context;
        public RepositoryBase(IMapper mapper, dungDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<HandleState> Delete(Guid Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
            if (entity is null)
            {
                return new HandleState(false, "Not found Entity");
            }
            return new HandleState(true, "Remove Success");
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<List<TModel>> GetAll()
        {
            return _mapper.Map<List<TModel>>(await _context.Set<T>().ToListAsync());
        }

        public async Task<TModel> GetByID(Guid Id)
        {
            return _mapper.Map<TModel>(await _context.Set<T>().FindAsync(Id));
        }

        public async Task<HandleState> Add(TModel model)
        {
            if (Existed(model).Result)
            {
                return new HandleState(false, "Entity Existed");
            }
            T entity = _mapper.Map<T>(model);
            await _context.Set<T>().AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new HandleState(true, "Entity Added");
            }
            return new HandleState(false, "Entity Not Added");
        }

        public async Task<HandleState> Save()
        {
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new HandleState(true, "Database Saved");
            }
            return new HandleState(false, "Database Not Changed");
        }

        public async Task<List<TModel>> Paging(Expression<Func<T, bool>> predicate, int page, int size)
        {
            return _mapper.Map<List<TModel>>(await _context.Set<T>().Where(predicate).Skip(page * size).Take(size).ToListAsync());
        }

        public async Task<List<TModel>> Query(Expression<Func<T, bool>> predicate)
        {
            return _mapper.Map<List<TModel>>(await _context.Set<T>().Where(predicate).ToListAsync());
        }

        public async Task<HandleState> Update(TModel model)
        {
            if(Existed(model).Result){
                return new HandleState(false,"Entity Existed");
            }
            T entity = _mapper.Map<T>(model);
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new HandleState(true, "Entity Updated");
            }
            return new HandleState(false, "Entity Not Updated");
        }

        public async Task<HandleState> AddRange(List<TModel> models)
        {
            if (ExistedRange(models).Result)
            {
                return new HandleState(false, "Entities Existed");
            }
            IEnumerable<T> entities = _mapper.Map<IEnumerable<T>>(models);
            await _context.Set<T>().AddRangeAsync(entities);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new HandleState(true, "Entities Added");
            }
            return new HandleState(false, "Entities Not Added");
        }

        public async Task<HandleState> UpdateRange(List<TModel> models)
        {
            if (ExistedRange(models).Result)
            {
                return new HandleState(false, "Entities Existed");
            }
            var entities = _mapper.Map<List<T>>(models);
            _context.Set<T>().AttachRange(entities);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new HandleState(true, "Entities Updated");
            }
            return new HandleState(false, "Entities Not Updated");
        }

        public async Task<HandleState> DeleteRange(List<Guid> Ids)
        {
            _context.RemoveRange(Ids);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new HandleState(true, "Entities Deleted");
            }
            return new HandleState(false, "Entities Not Deleted");
        }

        private async Task<bool> Existed(TModel model){
            var entity=_mapper.Map<T>(model);
            return await _context.Set<T>().AnyAsync(x=>x.Equals(entity));
        }
        private async Task<bool> ExistedRange(List<TModel> models){
            var entities=_mapper.Map<List<T>>(models);
            return await _context.Set<T>().AnyAsync(x=>entities.Contains(x));
        }
    }

}