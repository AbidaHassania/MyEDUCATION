using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mobility.Models;

public class Demande
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CollabId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? EnfantId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string AnneeScolaire { get; set; } = null!;

    public string TypeOffre_actuel { get; set; } = null!;

    public string Etablissement_actuel { get; set; } = null!;

    public string VilleEtablissement_actuel { get; set; } = null!;

    public string TypeOffre_nouveau { get; set; } = null!;

    public string Etablissement_nouveau { get; set; } = null!;

    public string VilleEtablissement_nouveau { get; set; } = null!;

    public string? Statut { get; set; } 

    public DateTime createDate { get; set; } 

    public DateTime statutUpdated { get; set; } 


}