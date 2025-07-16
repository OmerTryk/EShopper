using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EShopper.Catalog.Entities
{
    public class ProductImage
    {
        public string ProductImageUrl { get; set; }
        public string ProductImageDescription { get; set; }
    }
}
