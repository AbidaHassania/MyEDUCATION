using HistoriqueApi.Models;
using HistoriqueApi.Services;
using MassTransit;
using Shared.Models.RabbitMqModel;

     
namespace HistoriqueApi.Consumer;
     
    public class DemandeCreatedConsumer : IConsumer<DemandeCreated>
    {
        private readonly DemandesService _DemandesService;
        public DemandeCreatedConsumer(DemandesService DemandesService)
        {
            _DemandesService = DemandesService;
        }
        public async Task Consume(ConsumeContext<DemandeCreated> context)
        {
            var newDemande = new Demande{
                Id = context.Message.Id,
                CollabId = context.Message.CollabId,
                Nom = context.Message.Nom,
                Prenom = context.Message.Prenom,
                Type = context.Message.Type,
                Statut = context.Message.Statut,
                Annee_scolaire = context.Message.Annee_scolaire,
                StatutUpdated = context.Message.StatutUpdated,
                CreateDate = context.Message.CreateDate,
            };
            await _DemandesService.CreateAsync(newDemande);
        }
    }