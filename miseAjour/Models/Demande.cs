using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace miseAjour.Models;

public class Demande
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? CollabId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? EnfantId { get; set; }
    public string? Prenom { get; set; } 

    public string? Nom { get; set; } 

    public string? VilleResidense { get; set; } 

    public string? Scolarité { get; set; }

    public string? codeNational { get; set; }

    public DateTime DateNaissance { get; set; } 

    public string? TypeOffre { get; set; } 

    public string? Etablissement { get; set; }

    public string? NiveauScolaire { get; set; } 

    public string? VilleEtablissement { get; set; } 

    public string? Statut { get; set; } 

    public DateTime createDate { get; set; } 

    public DateTime statutUpdated { get; set; } 
}