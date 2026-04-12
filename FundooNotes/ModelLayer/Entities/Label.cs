//namespace ModelLayer.Entities
//{
//    public class Label
//    {
//        public int LabelId { get; set; }
//        public string Name { get; set; }
//        public int UserId { get; set; }
//        public DateTime CreatedAt { get; set; }


//    }
//}


//====================================================================================================
//MONGO SETUP
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ModelLayer.Entities
{
    public class Label
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }   // 🔥 THIS FIXES THE ERROR

        public string LabelName { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}