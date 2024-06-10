using Food_Recipe_Core.Context;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Infra.Repos;
using Food_Recipe_Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddDbContext<FoodRecipeDBContext>(
    cnn => cnn.UseMySQL(builder.Configuration.GetConnectionString("mysqlconnect")));
builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICategoryRepos, CategoryRepos>();
builder.Services.AddScoped<ICuisineServices, CuisineServices>();
builder.Services.AddScoped<ICuisineRepos, CuisineRepos>();
builder.Services.AddScoped<IDishIngredientsServices, DishIngredientsServices>();
builder.Services.AddScoped<IDishIngredientsRepos, DishIngredientsRepos>();
builder.Services.AddScoped<IDishPreparingStepsServices, DishPreparingStepsServices>();
builder.Services.AddScoped<IDishPreparingStepsRepos, DishPreparingStepsRepos>();
builder.Services.AddScoped<IDishServices, DishServices>();
builder.Services.AddScoped<IDishRepos, DishRepos>();
builder.Services.AddScoped<IDishRequestServices, DishRequestServices>();
builder.Services.AddScoped<IDishRequestRepos, DishRequestRepos>();
builder.Services.AddScoped<IIngredientServices, IngredientServices>();
builder.Services.AddScoped<IIngredientRepos, IngredientRepos>();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddScoped<ILoginRepos, LoginRepos>();
builder.Services.AddScoped<ISubscriptionServices, SubscriptionServices>();
builder.Services.AddScoped<ISubscriptionRepos, SubscriptionRepos>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepos, UserRepos>();
builder.Services.AddScoped<IUserSubscriptionServices, UserSubscriptionServices>();
builder.Services.AddScoped<IUserSubscriptionRepos, UserSubscriptionRepos>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Accounting Management",
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
string loggerPath = configuration.GetSection("Logger").Value;
//use the above line to store file path in appsetings

Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(loggerPath, rollingInterval: RollingInterval.Day).
                CreateLogger();


var app = builder.Build();

try
{
    Log.Information("Food Recipe API Has been Launched Successfully");
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();


}
catch (Exception ex)
{
    Log.Error("Something Went Wrong On Starting Application");
    Log.Error($"Error: {ex}");
}
