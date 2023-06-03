using CollabsApi.Models;
using CollabsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollabsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CollabsController : ControllerBase
{
    private readonly CollabService _CollabsService;
    private readonly EnfantsService _EnfantsService;

    public CollabsController(CollabService CollabsService, EnfantsService EnfantsService)
    {
        _CollabsService = CollabsService;
        _EnfantsService = EnfantsService;


    }

    [HttpGet]
    public async Task<List<Collab>> Get() =>
        await _CollabsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Collab>> Get(string id)
    {
        var Collab = await _CollabsService.GetAsync(id);


        if (Collab is null)
        {
            return NotFound();
        }
        if (Collab.Enfants.Count > 0)
        {
            var tempList = new List<Enfant>();
            foreach (string EnfantId in Collab.Enfants)
            {
                var Enfant = await _EnfantsService.GetAsync(EnfantId);
                if (Enfant != null)
                    tempList.Add(Enfant);
            }
            Collab.EnfantList = tempList;
        }

        return Collab;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Collab newCollab)
    {
        await _CollabsService.CreateAsync(newCollab);

        return CreatedAtAction(nameof(Get), new { id = newCollab.Id }, newCollab);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Collab updatedCollab)
    {
        var Collab = await _CollabsService.GetAsync(id);

        if (Collab is null)
        {
            return NotFound();
        }

        updatedCollab.Id = Collab.Id;

        await _CollabsService.UpdateAsync(id, updatedCollab);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var Collab = await _CollabsService.GetAsync(id);

        if (Collab is null)
        {
            return NotFound();
        }

        await _CollabsService.RemoveAsync(id);

        return NoContent();
    }
}