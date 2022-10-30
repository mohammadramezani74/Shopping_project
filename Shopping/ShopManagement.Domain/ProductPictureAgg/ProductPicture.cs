using FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture:EntityBase
    {
        public long ProductId { get; private set; }
        public string Picture { get;private set; }
        public string  PictureAlt { get;private set; }
        public string PictureTitle { get;private set; }
        public bool IsRemoved { get; set; }

        public ProductPicture(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            IsRemoved = false;  
        }
        public void Edit(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
         
        }
        public void removed()
        {
            IsRemoved= true;
        }
        public void restore()
        {
            IsRemoved = false;
        }
    }

}
