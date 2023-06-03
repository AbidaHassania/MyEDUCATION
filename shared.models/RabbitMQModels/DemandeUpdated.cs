namespace Shared.Models.RabbitMqModel;
     
    public class DemandeUpdated
    {
        public string? Id { get; set; }
        public string? Statut { get; set; } 

        public DateTime StatutUpdated { get; set;}

    }