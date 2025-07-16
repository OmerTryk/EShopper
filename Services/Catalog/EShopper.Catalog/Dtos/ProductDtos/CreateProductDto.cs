using EShopper.Catalog.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace E_Shopper.Catalog.Dtos.ProductDetailDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
    }
}
