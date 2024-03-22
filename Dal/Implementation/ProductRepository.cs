using Microsoft.EntityFrameworkCore;
using Store.Dal.Interfaces;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.Implementation
{
    public class ProductRepository : IProductRepository
    {
        public async Task<bool> Create(Product product)
        {
            using (AppDbContext context = new())
            {
                var saveProduct = context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);

                if (await saveProduct != null)
                {
                    return false;
                }

                context.Products.Add(product);

                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> Delete(Product product)
        {
            using (AppDbContext context = new())
            {
                var pr = await context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);

                if (pr == null) 
                {
                    return false;
                }

                context.Products.Remove(pr);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public List<Product> GetAll()
        {
            using (AppDbContext context = new())
            {
                return context.Products.Include(x => x.ImageFile).ToList();
            }
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            using (AppDbContext context = new())
            {
                var pr = await context.Products.Include(c => c.ImageFile).Where(x => x.Name == name).ToListAsync();

                if(pr == null)
                {
                    return new List<Product>();
                }

                return pr;
            }
        }

        public async Task<byte[]> GetDefaultImage()
        {
            using (AppDbContext context = new())
            {
                var imageFile = await context.ImageFiles.FirstOrDefaultAsync(x => x.FileName == "DefaultImg.png");

                return imageFile.ImageData;
            }
        }

        public async Task<bool> Update(Product product)
        {
            using (AppDbContext context = new())
            {
                try
                {
                    context.Update(product);

                    await context.SaveChangesAsync();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
