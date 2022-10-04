using FrameWork.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductActegoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IproductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var Operation = new OperationResult();
            if (_productCategoryRepository.Exists(x=>x.Name==command.Name))
                return Operation.Failed("امکان ثبت رکورد تکراری وجود ندارد لطفا مجدد تلاش کنید");
          var Slug = command.Slug.GenerateSlug();
            var ProductCategory = new ProductCategory(command.Name, command.Description
                , command.Picture, command.PictureAlt, command.PictureTitle, command.KeyWords,
                command.MetaDiscription, Slug);
            _productCategoryRepository.Create(ProductCategory);
            _productCategoryRepository.SaveChanges();
            return Operation.succedded();

        }

        public OperationResult Edit(EditProductCategory command)
        {
            var Operation=new OperationResult();
            var productCategory = _productCategoryRepository.GetBy(command.Id);
            if (productCategory == null) return Operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد لطفا مجدد تلاش بفرمایید");
            if(_productCategoryRepository.Exists(x=>x.Name==command.Name && x.Id!=command.Id))
                return Operation.Failed("امکان ویرایش رکورد تکراری وجود ندارد لطفا مجدد تلاش کنید");
            var Slug = command.Slug.GenerateSlug();
            productCategory.Edit(command.Name, command.Description
                , command.Picture, command.PictureAlt, command.PictureTitle, command.KeyWords,
                command.MetaDiscription, Slug);
            _productCategoryRepository.SaveChanges();
            return Operation.succedded();
        }

        public EditProductCategory GetDetails(long Id)
        {

           return _productCategoryRepository.GetDetails(Id);
        
                }
        public List<ProductCategoryViewModel> search(ProductCategorySearchModel model)
        {
            return _productCategoryRepository.Search(model);
                }
    }
}
