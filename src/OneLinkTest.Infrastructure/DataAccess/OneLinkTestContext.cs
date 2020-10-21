﻿using Microsoft.EntityFrameworkCore;
using OneLinkTest.Domain.Areas;
using OneLinkTest.Domain.Areas.Subareas;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Infrastructure.DataAccess
{
    public class OneLinkTestContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public OneLinkTestContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Subarea> Subareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new System.ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OneLinkTestContext).Assembly);
            SeedData.Seed(modelBuilder);
        }
    }
}
