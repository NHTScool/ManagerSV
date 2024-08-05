using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ManagerSV.Models
{
    [BsonIgnoreExtraElements]
    public class Student
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; set; }= string.Empty;

        [BsonElement("mssv")]
        public int Mssv { get; set; }

        [BsonElement("course")]
        public int Course { get; set; }

        [BsonElement("career")]
        public string Carrer { get; set; } = string.Empty;
    }
}
