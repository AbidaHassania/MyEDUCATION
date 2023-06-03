using CollabsApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CollabsApi.Services;

public class DemandesService
{
private readonly IMongoCollection<Demande> _dbCollection;
  
    public DemandesService(
        IOptions<MyOCPDatabaseSettings> MyOCPDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MyOCPDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MyOCPDatabaseSettings.Value.DatabaseName);

        _dbCollection = mongoDatabase.GetCollection<Demande>(
            MyOCPDatabaseSettings.Value.DemandesCollectionName);

    }

    public async Task<List<Demande>> GetAsync() =>
        await _dbCollection.Find(_ => true).ToListAsync();

    public async Task<Demande?> GetAsync(string id) =>
        await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Demande newDemande) =>
        await _dbCollection.InsertOneAsync(newDemande);

    public async Task UpdateAsync(string id, Demande updatedDemande) =>
        await _dbCollection.ReplaceOneAsync(x => x.Id == id, updatedDemande);

    public async Task RemoveAsync(string id) =>
        await _dbCollection.DeleteOneAsync(x => x.Id == id);
}