


using FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,10000,ErrorMessage =ValidationMessages.ISRequired)]
        public long ProductId { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.ISRequired)]
        public string PictureTitle { get;  set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
