using NetMicroservices.SqlWrapper.Nuget;
using ProjectDetail.Application;
using ProjectDetail.Persistence;
using ProjectDetail.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<ProjectContext>((context, services) =>
 {
     var logger = services.GetService(typeof(ILogger<ProjectContextSeed>)) as ILogger<ProjectContextSeed>;

     ProjectContextSeed
            .SeedAsync(context, logger)
            .Wait();
 });


app.UseAuthorization();

app.MapControllers();

app.Run();
