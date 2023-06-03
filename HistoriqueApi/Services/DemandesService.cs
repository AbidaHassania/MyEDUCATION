using HistoriqueApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HistoriqueApi.Services;

public class DemandesService
{
    private readonly IMongoCollection<Demande> _HistoriqueCollection;

    public DemandesService(
        IOptions<HistoriqueDatabaseSettings> HistoriqueDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            HistoriqueDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            HistoriqueDatabaseSettings.Value.DatabaseName);

        _HistoriqueCollection = mongoDatabase.GetCollection<Demande>(
            HistoriqueDatabaseSettings.Value.HistoriqueCollectionName);
    }

    public async Task<List<Demande>> GetAsync() =>
        await _HistoriqueCollection.Find(_ => true).ToListAsync();

    public async Task<Demande> GetAsync(string id) =>
        await _HistoriqueCollection.Find(x => x.Id == id).FirstOrDefaultAsync();


    public async Task CreateAsync(Demande newDemande) =>
        await _HistoriqueCollection.InsertOneAsync(newDemande);

    public async Task UpdateAsync(string id, Demande updatedDemande) =>
        await _HistoriqueCollection.ReplaceOneAsync(x => x.Id == id, updatedDemande);

    public async Task RemoveAsync(string id) =>
        await _HistoriqueCollection.DeleteOneAsync(x => x.Id == id);
}