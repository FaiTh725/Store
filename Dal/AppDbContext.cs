using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Store.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal
{
    public class AppDbContext : DbContext
    {
        protected const string jsonPath = "appsettings.json";

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*var file = File.ReadAllText(jsonPath);

            AppConfig appConfig = JsonConvert.DeserializeObject<AppConfig>(file);*/

            optionsBuilder.UseSqlServer("Server=FaiTh;Database=ProductStore;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }

    public class ConnectionStringsConfig
    {
        public string Default { get; set; }
    }

    public class AppConfig
    {
        public ConnectionStringsConfig ConnectionStrings { get; set; }
    }
}
