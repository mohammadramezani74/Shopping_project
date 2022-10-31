using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using System;
using System.Collections.Generic;

namespace HostService.Areas.Adminstration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductPictureSearchViewModel model;
        public List<ProductPictureViewModel> productPictures;
        public SelectList Products;
        private readonly IProductPictureApplication _service;
        private readonly IProductApplication _Productservice;
        public IndexModel(IProductPictureApplication service, IProductApplication Productservice)
        {
            _service = service;
            _Productservice = Productservice;
        }

        public void OnGet(ProductPictureSearchViewModel model)
        {
            try
            {
                Products = new SelectList(_Productservice.GetProducts(), "Id", "Name");
                productPictures = _service.GetAll(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture();
            command.Products = _Productservice.GetProducts();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateProductPicture createProductCategory)
        {
            var result = _service.Create(createProductCategory);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var result = _service.GetDetails(id);
            result.Products = _Productservice.GetProducts();
            return Partial("Edit", result);
        }
        public JsonResult OnPostEdit(EditProductPicture editProductCategory)
        {
            var result = _service.Edit(editProductCategory);
            return new JsonResult(result);
        }
        public IActionResult OnGetRestore(long Id)
        {
            var result = _service.Restore(Id);
            if (result.IsSucceded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRemove(long id)
        {
            var result = _service.Remove(id);
            if (result.IsSucceded)
            {
                return RedirectToPage("./Index");
            }
            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
