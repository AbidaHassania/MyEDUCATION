namespace Shared.Models.RabbitMqModel;
     
    public class DemandeCreated
    {
        public string? Id { get; set; }
        public string? CollabId { get; set; } 

    public string? Nom { get; set; }

    public string? Prenom { get; set; }  

    public string? Type { get; set; } 

    public string? Statut { get; set; } 

    public string? Annee_scolaire { get; set; } 

    public DateTime StatutUpdated { get; set;}

    public DateTime CreateDate { get; set;}
    }