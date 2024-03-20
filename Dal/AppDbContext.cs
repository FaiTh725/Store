using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Store.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal
{
    public class AppDbContext : DbContext
    {
        protected const string jsonPath = "~appsetting.json";

        public DbSet<Product> Products { get; set; }

        public DbSet<Avatar> Avatars { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var file = File.ReadAllText(jsonPath);

            var connectionString = JsonConvert.DeserializeObject<string>("Default");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
