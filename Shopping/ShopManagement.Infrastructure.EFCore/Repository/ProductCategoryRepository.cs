using FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductActegoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> ,IProductCategoryRepository
    {
        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context):base(context)
        {
            _context = context;
        }

       

        public EditProductCategory GetDetails(long id)
        {
            return _context.productCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Slug = x.Slug,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDiscription = x.MetaDiscription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).FirstOrDefault(x => x.Id == id);
        }

      

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel model)
        {
            var query=_context.productCategories.Select(x => new ProductCategoryViewModel
            {Picture=x.Picture,
            Id=x.Id,
            Name=x.Name,
           CreationDate=x.CreationDate.ToShortDateString(),

            }).AsQueryable();
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                query = query.Where(x => x.Name.Contains( model.Name));
            }
            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}
