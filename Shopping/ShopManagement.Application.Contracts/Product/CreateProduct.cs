using FrameWork.Application;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string Name { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string Code { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public double UnitPrice { get;  set; }
        public bool IsInStock { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string KeyWords { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string MetaDiscription { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string Slug { get;  set; }
        [Range(1,100000,ErrorMessage = ValidationMessages.ISRequired)]
        public long CategoryId { get;  set; }
        public List<ProductCategoryViewModel> Categories { get; set; }
    }
}
