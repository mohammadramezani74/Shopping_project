using FrameWork.Domain;
using ShopManagement.Domain.ProductActegoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product: EntityBase
    {
        public string Name { get;private set; }
        public string Code { get;private set; }    
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get;private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDiscription { get; private set; }
        public string Slug { get; private set; }

        public long CategoryId { get;private set; }
        public ProductCategory Category { get; private set; }

        public Product(string name, string code, double unitPrice, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle
            , string keyWords, string metaDiscription, string slug, long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDiscription = metaDiscription;
            Slug = slug;
            CategoryId = categoryId;
            IsInStock = true;
        }
        public void Edit (string name, string code, double unitPrice, string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle
         , string keyWords, string metaDiscription, string slug, long categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            KeyWords = keyWords;
            MetaDiscription = metaDiscription;
            Slug = slug;
            CategoryId = categoryId;
        }
        public void InStuck()
        {
           IsInStock = true;
        }
        public void notInStuck()
        {
           IsInStock = false;
        }
    }
}
