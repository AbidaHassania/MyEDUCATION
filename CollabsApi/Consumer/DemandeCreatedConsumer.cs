using CollabsApi.Models;
using CollabsApi.Services;
using MassTransit;
using Shared.Models.RabbitMqModel;

     
namespace CollabsApi.Consumer;
     
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
                Type = context.Message.Type
            };
            await _DemandesService.CreateAsync(newDemande);
        }
    }