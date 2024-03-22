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
using System.Windows;

namespace Store.Dal
{
    public class AppDbContext : DbContext
    {
        protected const string jsonName = "appsettings.json";

        public DbSet<Product> Products { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var json = File.ReadAllText(jsonName);

            AppConfig appConfig = JsonConvert.DeserializeObject<AppConfig>(json);

            optionsBuilder.UseSqlServer(appConfig.ConnectionString);
            //optionsBuilder.UseSqlServer("Server=FaiTh;Database=ProductStore;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
