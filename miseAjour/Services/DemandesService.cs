using miseAjour.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace miseAjour.Services;

public class DemandesService
{
    private readonly IMongoCollection<Demande> _UpdateCollection;

    public DemandesService(
        IOptions<UpdateDatabaseSettings> UpdateDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            UpdateDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            UpdateDatabaseSettings.Value.DatabaseName);

        _UpdateCollection = mongoDatabase.GetCollection<Demande>(
            UpdateDatabaseSettings.Value.UpdateCollectionName);
    }

    public async Task<List<Demande>> GetAsync() =>
        await _UpdateCollection.Find(_ => true).ToListAsync();

    public async Task<Demande?> GetAsync(string id) =>
        await _UpdateCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Demande newDemande) =>
        await _UpdateCollection.InsertOneAsync(newDemande);

    public async Task UpdateAsync(string id, Demande updatedDemande) =>
        await _UpdateCollection.ReplaceOneAsync(x => x.Id == id, updatedDemande);

    public async Task RemoveAsync(string id) =>
        await _UpdateCollection.DeleteOneAsync(x => x.Id == id);
}