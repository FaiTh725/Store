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

        public List<Product> GetAll();

        public Task<bool> Delete(Product product);

        public Task<bool> Update(Product product);

        public Task<byte[]> GetDefaultImage();

        public Task<IEnumerable<Product>> GetByName(string name);
    }
}
