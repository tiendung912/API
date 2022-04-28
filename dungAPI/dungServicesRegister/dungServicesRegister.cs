using System.Reflection;
using dungDAL.dungContext;
using dungDDL.IRepositories;
using dungDDL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace dungAPI.dungServicesRegister
{
    public static class dungServicesRegister
    {
        public static void addDungServicesRegister(this IServiceCollection serviceDescriptors, IConfiguration configuration)
        {
            // Add services to the container.

            serviceDescriptors.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            serviceDescriptors.AddEndpointsApiExplorer();
            serviceDescriptors.AddSwaggerGen();
            // Connect SQL
            serviceDescriptors.AddDbContext<dungDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("dungConnectionString")));
            // Registed Services
            serviceDescriptors.AddTransient<ICategoryRepository,CategoryRepository>();
            // Registed Mapper
            serviceDescriptors.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}