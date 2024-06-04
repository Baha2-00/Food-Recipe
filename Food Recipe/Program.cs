using Food_Recipe_Core.Context;
using Food_Recipe_Core.IRepos;
using Food_Recipe_Core.IServices;
using Food_Recipe_Infra.Repos;
using Food_Recipe_Infra.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
