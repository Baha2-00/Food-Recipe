using Food_Recipe_Core.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Recipe_Core.Models.EntityConfiguration
{
    public class DishPreparingStepsEntityConfiguration : IEntityTypeConfiguration<DishPreparingSteps>
    {
        public void Configure(EntityTypeBuilder<DishPreparingSteps> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.serial).IsRequired();
            builder.Property(x => x.Title).IsRequired();
        }
    }
}
