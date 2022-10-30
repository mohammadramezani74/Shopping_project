using FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var Operation=new OperationResult();
            if(_productRepository.Exist(x=>x.Name==command.Name))
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.GenerateSlug();
            var product=new Product(command.Name,command.Code,command.UnitPrice,command.ShortDescription,command.Description,command.Picture
                ,command.PictureAlt,command.PictureTitle,command.KeyWords,command.MetaDiscription, slug, command.CategoryId);
            _productRepository.Create(product);
            _productRepository.Savechanges();
            return Operation.succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var Operation = new OperationResult();
            var product=_productRepository.Get(command.Id);
            if(product==null) return Operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productRepository.Exist(x => x.Name == command.Name&& x.Id!=command.Id))
                return Operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.GenerateSlug();
            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture
                , command.PictureAlt, command.PictureTitle, command.KeyWords, command.MetaDiscription, slug, command.CategoryId);
            _productRepository.Savechanges();
            return Operation.succedded();
        }

        public EditProduct GetDetails(long Id)
        {
            return _productRepository.GetDetails(Id);
        }

        public OperationResult InStuck(long id)
        {
            var Operation = new OperationResult();
            var product = _productRepository.Get(id);
            if (product == null) return Operation.Failed(ApplicationMessages.RecordNotFound);
            product.InStuck();
            _productRepository.Savechanges();
            return Operation.succedded();
        }

        public OperationResult NotInStuck(long id)
        {
            var Operation = new OperationResult();
            var product=_productRepository.Get(id);
            if (product == null) return Operation.Failed(ApplicationMessages.RecordNotFound);
            product.notInStuck();
            _productRepository.Savechanges();
            return Operation.succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
          return _productRepository.Search(searchModel);
        }
    }
}
