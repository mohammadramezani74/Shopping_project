﻿

using FrameWork.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult InStuck(long id);
        OperationResult NotInStuck(long id);
        EditProduct GetDetails(long Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
