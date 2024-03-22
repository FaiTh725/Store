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

                return true;
            }
        }

        public async Task<IQueryable<Product>> GetAll()
        {
            using (AppDbContext context = new())
            {
                return context.Products;
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

        public Task<bool> Update()
        {
            throw new NotImplementedException();
        }
    }
}
