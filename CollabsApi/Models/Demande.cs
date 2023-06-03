using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollabsApi.Models;

public class Demande : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    public string? Type { get; set; }

}