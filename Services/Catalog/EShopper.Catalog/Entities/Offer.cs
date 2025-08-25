using MongoDB.Bson.Serialization.Attributes;

namespace E_Shopper.Catalog.Entities
{
    public class Offer
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string OfferId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }
}
