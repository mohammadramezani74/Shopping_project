using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;

namespace HostService.Areas.Adminstration.Pages.Shop.ProductCategory
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel model;
        public List<ProductCategoryViewModel> productcategoryList;
        private readonly IproductCategoryApplication _service;

        public IndexModel(IproductCategoryApplication service)
        {
            _service = service;
        }

        public void OnGet(ProductCategorySearchModel model)
        {
          productcategoryList=  _service.search(model);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public JsonResult OnPostCreate(CreateProductCategory createProductCategory)
        {
          var result=  _service.Create(createProductCategory);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
           var result= _service.GetDetails(id);
            return Partial("./Edit", result);
        }
        public JsonResult OnPostEdit(EditProductCategory editProductCategory)
        {
            var result=_service.Edit(editProductCategory);
            return new JsonResult(result);
        }
        public IActionResult OnGetDelete(long Id)
        {
            var result = _service.RemoveAsync(Id);
            return RedirectToAction("OnGet");
        }
    }
}
