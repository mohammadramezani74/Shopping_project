using FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture>, IProductPictureRepository
    { private readonly ShopContext _shopContext;
        public ProductPictureRepository( ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditProductPicture GetDetails(long Id)
        {
           return _shopContext.ProductPictures
                .Select(x=>new EditProductPicture {
                Id=x.Id,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                ProductId=x.ProductId})
                .FirstOrDefault(x => x.Id == Id);
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchViewModel searchViewModel)
        {
            var query = _shopContext.ProductPictures.AsNoTracking()
                .Include(x=>x.Product).Select(x => new ProductPictureViewModel {
               Id=x.Id,
               Product=x.Product.Name,
               Picture=x.Picture,
               CreationDate=x.CreationDate.ToString(),
               ProductId=x.ProductId,
                    IsRemoved=x.IsRemoved,

                });
            if (searchViewModel.ProductId != 0)
            {
                query=query.Where(x=>x.ProductId == searchViewModel.ProductId);
            }
            return query.OrderByDescending(x=>x.CreationDate).ToList();
        }
    }
}
