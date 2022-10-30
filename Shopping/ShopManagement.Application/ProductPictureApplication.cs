using FrameWork.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
           var operation=new OperationResult();
            if (_productPictureRepository.Exist(x => x.Picture == command.Picture && x.ProductId==command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var productPicture = new ProductPicture(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.Savechanges();
            return operation.succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var ProductPicture=_productPictureRepository.Get(command.Id);
            if(ProductPicture==null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productPictureRepository.Exist(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
            {
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            ProductPicture.Edit(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Savechanges();
            return operation.succedded();

        }

        public List<ProductPictureViewModel> GetAll(ProductPictureSearchViewModel search)
        {
           return _productPictureRepository.Search(search);
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if (ProductPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
          
            ProductPicture.removed();
            _productPictureRepository.Savechanges();
            return operation.succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var ProductPicture = _productPictureRepository.Get(id);
            if (ProductPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            ProductPicture.restore();
            _productPictureRepository.Savechanges();
            return operation.succedded();
        }
    }
}
