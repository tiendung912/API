namespace dungAPI.dungServicesRegister
{
    public static class dungServicesRegister
    {
        public static void addDungServicesRegister(this IServiceCollection serviceDescriptors)
        {
            // Add services to the container.

            serviceDescriptors.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            serviceDescriptors.AddEndpointsApiExplorer();
            serviceDescriptors.AddSwaggerGen();
        }
    }
}