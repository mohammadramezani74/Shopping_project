﻿using FrameWork.Domain;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository: IRepository<long, Product>
    {
        EditProduct GetDetails(long Id);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
