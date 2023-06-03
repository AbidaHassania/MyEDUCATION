using HistoriqueApi.Models;
using HistoriqueApi.Services;
using MassTransit;
using Shared.Models.RabbitMqModel;

     
namespace HistoriqueApi.Consumer;
     
    public class DemandeUpdatedConsumer : IConsumer<DemandeUpdated>
    {
        private readonly DemandesService _DemandesService;
        public DemandeUpdatedConsumer(DemandesService DemandesService)
        {
            _DemandesService = DemandesService;
        }
        
        
        public async Task Consume(ConsumeContext<DemandeUpdated> context)
        {
            var updatedDemande = await _DemandesService.GetAsync(context.Message.Id);
            
            updatedDemande.Statut = context.Message.Statut;
            updatedDemande.StatutUpdated = context.Message.StatutUpdated;
            await _DemandesService.UpdateAsync(context.Message.Id, updatedDemande);
        
        }
    }