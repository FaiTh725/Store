using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal.Interfaces
{
    public interface IProductRepository
    {
        public Task<bool> Create(Product product);

        public Task<IQueryable<Product>> GetAll();

        public Task<bool> Delete(Product product);

        public Task<bool> Update();
    }
}
