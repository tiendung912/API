using dungAPI.dungapplicationBuilderlicationBuilder;
using dungAPI.dungServicesRegister;

var builder = WebApplication.CreateBuilder(args);

builder.Services.addDungServicesRegister(builder.Configuration);

var app = builder.Build();

app.useDungBuilder(app.Environment.IsDevelopment());

app.UseAuthorization();

app.MapControllers();

app.Run();
