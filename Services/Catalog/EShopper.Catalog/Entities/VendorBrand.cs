using MongoDB.Bson.Serialization.Attributes;

namespace E_Shopper.Catalog.Entities
{
    public class VendorBrand
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string VendorBrandId { get; set; }
        public string ImageUrl { get; set; }
    }
}
