using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HistoriqueApi.Models;

public class Demande
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string CollabId { get; set; } 

    public string Nom { get; set; }

    public string Prenom { get; set; }  

    public string Type { get; set; } 

    public string Statut { get; set; } 

    public string Annee_scolaire { get; set; } 

    public DateTime StatutUpdated { get; set;}

    public DateTime CreateDate { get; set;}


}