using AutoMapper;
using dungDAL.dungContext;
using dungDAL.Models;
using dungDDL.IRepositories;
using dungDDL.ViewModels;

namespace dungDDL.Repositories
{
    public class CategoryRepository : RepositoryBase<Category, CategoryVM>, ICategoryRepository
    {
        public CategoryRepository(IMapper mapper, dungDbContext context) : base(mapper, context)
        {
        }
    }
}