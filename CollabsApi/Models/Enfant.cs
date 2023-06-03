using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CollabsApi.Models;

public class Enfant
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? Nom { get; set; } = null!;

    public string? Prenom { get; set; }


    public string code_national { get; set; } = null!;

    public DateTime Date_naissance { get; set; }

    public string Ville_de_residence { get; set; } = null!;

    public string Etablissement { get; set; } = null!;
    public string Adresse_du_tuteur { get; set; } = null!;

    public string Niveau_scolaire { get; set; } = null!;

    public string Scolarite { get; set; } = null!;

    public string Telephone_pro_du_tuteur { get; set; } = null!;


}