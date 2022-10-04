
using FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IproductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long Id);
        List<ProductCategoryViewModel> search(ProductCategorySearchModel model);
    }
}
