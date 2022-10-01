using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductActegoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory category);
        ProductCategory GetBy(long id);
        List<ProductCategory> GetAll();
    }
}
