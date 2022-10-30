using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;

namespace HostService.Areas.Adminstration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductSearchModel model;
        public List<ProductViewModel> products;
        public SelectList ProductCategories;
        private readonly IProductApplication _service;
        private readonly IproductCategoryApplication _Categoryservice;
        public IndexModel(IProductApplication service, IproductCategoryApplication categoryservice)
        {
            _service = service;
            _Categoryservice = categoryservice;
        }

        public void OnGet(ProductSearchModel model)
        {
            try
            {
                ProductCategories = new SelectList(_Categoryservice.GetProductCategories(), "Id", "Name");
                products =  _service.Search(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
       
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct();
            command.Categories=_Categoryservice.GetProductCategories();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProduct createProductCategory)
        {
          var result=  _service.Create(createProductCategory);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
           var result= _service.GetDetails(id);
            result.Categories = _Categoryservice.GetProductCategories();
            return Partial("Edit", result);
        }
        public JsonResult OnPostEdit(EditProduct editProductCategory)
        {
            var result=_service.Edit(editProductCategory);
            return new JsonResult(result);
        }
        public IActionResult OnGetNotInStock(long Id)
        {
         var result=   _service.NotInStuck(Id);
            if (result.IsSucceded)
            {
                return RedirectToPage("./Index");
            }
         Message=result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetIsInStock(long id)
        {
            var result = _service.InStuck(id);
            if (result.IsSucceded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
