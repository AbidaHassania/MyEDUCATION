using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollabsApi.Models;

public interface IEntity
{
    [BsonRepresentation(BsonType.ObjectId)]
    string? Id { get; set; }
    
}
