using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollabsApi.Models;

public class Collab : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    //[BsonElement("Name")]
    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public int? Matricule { get; set; }
    public string? Entite_d_affectation { get; set; }

    public string? Site_d_affectation { get; set; }


    [BsonRepresentation(BsonType.ObjectId)]
    public List<string> Enfants { get; set; }
    [BsonIgnore]
    public List<Enfant> EnfantList { get; set; }
}