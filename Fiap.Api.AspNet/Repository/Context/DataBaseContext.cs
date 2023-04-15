using Fiap.Api.AspNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Fiap.Api.AspNet.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<RioModel> Rio { get; set; }
        public DbSet<AreaDeRiscoModel> AreaDeRisco { get; set; }
        public DbSet<BoiaModel> Boia { get; set; }
        public DbSet<PluviometroModel> Pluviometro { get; set; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DataBaseContext()
        {

        }

    }
}