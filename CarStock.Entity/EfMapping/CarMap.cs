using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStock.Entity.EfMapping
{
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasIndex(e => e.Plaka)
                      .IsUnique();
            builder.HasIndex(e => e.MotorNo)
                   .IsUnique();
        }
    }
}
