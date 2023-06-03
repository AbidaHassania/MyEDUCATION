using HistoriqueApi.Models;
using HistoriqueApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HistoriqueApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DemandesController : ControllerBase
{
    private readonly DemandesService _DemandesService;

    public DemandesController(DemandesService DemandesService) =>
        _DemandesService = DemandesService;

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