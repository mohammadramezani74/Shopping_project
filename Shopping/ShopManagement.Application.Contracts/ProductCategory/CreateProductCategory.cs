using FrameWork.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Display(Name ="نام")]
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string Name { get; set; }
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
    }
}
