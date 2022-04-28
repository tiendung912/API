using System.Linq.Expressions;
using dungDDL.ViewModels;

namespace dungDDL.IRepositories
{
    public interface IRepositoryBase<T, TModel> : IDisposable where T : class, new() where TModel : class
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetByID(Guid Id);
        Task<List<TModel>> Paging(Expression<Func<T, bool>> predicate,int page,int size);
        Task<List<TModel>> Query(Expression<Func<T, bool>> predicate);
        Task<HandleState> Add(TModel model);
        Task<HandleState> AddRange(List<TModel> models);
        Task<HandleState> Delete(Guid Id);
        Task<HandleState> DeleteRange(List<Guid> Ids);
        Task<HandleState> Update(TModel model);
        Task<HandleState> UpdateRange(List<TModel> models);
        Task<HandleState> Save();
    }
}