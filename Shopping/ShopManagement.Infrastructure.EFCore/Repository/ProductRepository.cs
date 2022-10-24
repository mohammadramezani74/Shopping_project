using FrameWork.Domain;
using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductActegoryAgg;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {private readonly ShopContext _shopContext;

        public ProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
        public EditProduct GetDetails(long Id)
        {
            return _shopContext.products.Select(p => new EditProduct
            {
                Id = Id,
                Name = p.Name,
                Description = p.Description,
                ShortDescription = p.ShortDescription,
                Slug = p.Slug,
                PictureAlt = p.PictureAlt,
                CategoryId = p.CategoryId,
                IsInStock = p.IsInStock,
                Code = p.Code,
                KeyWords = p.KeyWords,
                MetaDiscription = p.MetaDiscription,
                Picture=p.Picture,
                PictureTitle = p.PictureTitle,
                UnitPrice = p.UnitPrice,
            }).FirstOrDefault(x=>x.Id==Id);
        }

     

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _shopContext.products.AsNoTracking()
                .Include(x => x.Category).Select(_ => new ProductViewModel
                {
                    CategoryName = _.Category.Name,
                    CategoryId = _.Category.Id,
                    Code = _.Code,
                    Id = _.Id,
                    Name = _.Name,
                    Picture = _.Picture,
                    UnitPrice = _.UnitPrice,
                    CreationDate = _.CreationDate.ToString()
                }) ;
            if (string.IsNullOrEmpty(searchModel.Name))
            {
                query=query.Where(x=>x.Name.Contains(searchModel.Name));
            }
            if (string.IsNullOrEmpty(searchModel.Code))
            {
                query = query.Where(x => x.Code.Contains(searchModel.Code));
            }
            if (searchModel.CategoryId!=0)
            {
                query = query.Where(x => x.CategoryId==searchModel.CategoryId);
            }
            return query.OrderByDescending(x=>x.Id).ToList();
        }

    }
}
