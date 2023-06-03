using miseAjour.Models;
using miseAjour.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.RabbitMqModel;
using MassTransit;

namespace miseAjour.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemandesController : ControllerBase
{
    private readonly DemandesService _DemandesService;
    private readonly IPublishEndpoint _publishEndpoint;
    

    public DemandesController(DemandesService DemandesService, IPublishEndpoint publishEndpoint) 
    {
        _DemandesService = DemandesService;
        _publishEndpoint = publishEndpoint ;  


    }


    [HttpGet]
    public async Task<List<Demande>> Get() =>
        await _DemandesService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Demande>> Get(string id)
    {
        var Demande = await _DemandesService.GetAsync(id);

        if (Demande is null)
        {
            return NotFound();
        }

        return Demande;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Demande newDemande)
    {
        await _DemandesService.CreateAsync(newDemande);

        await _publishEndpoint.Publish<DemandeCreated>(new DemandeCreated{
            Id = newDemande.Id,
            CollabId = newDemande.CollabId,
            Nom = newDemande.Nom,
            Prenom = newDemande.Prenom,
            Type = "Demande de mise à jour",
            Statut = "envoyé",
            Annee_scolaire = "null",
            CreateDate = DateTime.Now


        });

        return CreatedAtAction(nameof(Get), new { id = newDemande.Id }, newDemande);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Demande updatedDemande)
    {
        var Demande = await _DemandesService.GetAsync(id);

        if (Demande is null)
        {
            return NotFound();
        }

        updatedDemande.Id = Demande.Id;

        await _DemandesService.UpdateAsync(id, updatedDemande);

        await _publishEndpoint.Publish<DemandeUpdated>(new DemandeUpdated{
            Id = updatedDemande.Id,
            Statut = updatedDemande.Statut,
            StatutUpdated = DateTime.Now


        });

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Demande = await _DemandesService.GetAsync(id);

        if (Demande is null)
        {
            return NotFound();
        }

        await _DemandesService.RemoveAsync(id);

        return NoContent();
    }
}