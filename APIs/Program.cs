using APIs.Configurations;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;


var builder = WebApplication.CreateBuilder(args);

ConfigureConnection(builder);
ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddOpenApiDocument();

//builder.Services.AddDbContext<TodoContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();


    //app.UseOpenApi();
    //app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureServices(IServiceCollection services)
{
    services.Configure<DeveloperDatabaseConfiguration>(builder.Configuration.GetSection("DeveloperDatabaseConfiguration"));
    //services.AddScoped<ICustomerService, CustomerService>();
}

void ConfigureConnection(WebApplicationBuilder builder)
{
    var sqlConnectionString = builder.Configuration?.GetSection("ConnectionStrings")?["SqlServerDefaultConnection"];
    var b = builder.Configuration?.GetSection("MongoDBConnectionStrings");

    builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseSqlServer(sqlConnectionString,
           builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

    //var dbContextOptionsBuilder = optionsBuilder.UseLazyLoadingProxies();
    //dbContextOptionsBuilder.ConfigureDbContext(sqlConnectionString);

}