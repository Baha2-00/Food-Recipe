using Food_Recipe_Core.Models.Entity;
using Food_Recipe_Core.Models.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Context
{
    public class FoodRecipeDBContext : DbContext
    {
        public FoodRecipeDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DishEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DishPreparingStepsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new IngredientsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LoginEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DishIngredientEntityConfiguration());
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Dish> Dishs { get; set; }
        public virtual DbSet<DishPreparingSteps> DishPreparingStep { get; set; }
        public virtual DbSet<Ingredients> Ingredient { get; set; }
        public virtual DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
