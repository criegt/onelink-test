using System;
using Microsoft.EntityFrameworkCore;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Domain.Areas.Subareas;

namespace OneLinkTest.Infrastructure.DataAccess
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            var area1 = new Area { AreaId = 1, Name = "Area1" };
            var subarea1 = new Subarea { SubareaId = 1, AreaId = 1, Name = "Subarea1" };

            builder.Entity<Area>()
                .HasData(area1);

            builder.Entity<Subarea>()
                .HasData(subarea1);
        }
    }
}
