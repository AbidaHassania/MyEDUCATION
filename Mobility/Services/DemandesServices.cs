using Mobility.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Mobility.Services;

public class DemandesService
{
    private readonly IMongoCollection<Demande> _MobilityCollection;

    public DemandesService(
        IOptions<MobilityDatabaseSettings> MobilityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MobilityDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MobilityDatabaseSettings.Value.DatabaseName);

        _MobilityCollection = mongoDatabase.GetCollection<Demande>(
            MobilityDatabaseSettings.Value.MobilityCollectionName);
    }

    public async Task<List<Demande>> GetAsync() =>
        await _MobilityCollection.Find(_ => true).ToListAsync();

    public async Task<Demande?> GetAsync(string id) =>
        await _MobilityCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Demande newDemande) =>
        await _MobilityCollection.InsertOneAsync(newDemande);

    public async Task UpdateAsync(string id, Demande updatedDemande) =>
        await _MobilityCollection.ReplaceOneAsync(x => x.Id == id, updatedDemande);

    public async Task RemoveAsync(string id) =>
        await _MobilityCollection.DeleteOneAsync(x => x.Id == id);

    public async Task<List<Demande>> GetAsyncByCollab(string Nom) =>
        await _MobilityCollection.Find(x => x.Nom == Nom).ToListAsync();

    /*public async Task<List<Demande>> GetAsyncByCollab(string id)
    {
        var demandes = await _MobilityCollection.Find(
            new { Demande.CollabId == id },
             new { name = 1 }).ToListAsync();

        return demandes;

    }*/
    


    
}