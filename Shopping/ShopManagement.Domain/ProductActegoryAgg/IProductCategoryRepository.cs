using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductActegoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory category);
        ProductCategory GetBy(long id);
        List<ProductCategory> GetAll();
        bool Exists(Expression<Func<ProductCategory,bool>> expression);
        void SaveChanges();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel model);
    }
}
