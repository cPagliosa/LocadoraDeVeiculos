﻿using System.Reflection;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraVeiculos.Infra.Orm.Compartinhado
{
    public class LocadoraDbContext : DbContext
    {
        public DbSet<GrupoAutomovel> GruposAutomoveis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeadorGrupoAutomoveis());
            base.OnModelCreating(modelBuilder);
        }
    }
}
