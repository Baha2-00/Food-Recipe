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
    public class DishRequestEntityConfiguration : IEntityTypeConfiguration<DishRequest>
    {
        public void Configure(EntityTypeBuilder<DishRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
