using CollabsApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CollabsApi.Services;

public class EnfantsService
{
    private readonly IMongoCollection<Enfant> _dbCollection;

    public EnfantsService(
        IOptions<MyOCPDatabaseSettings> MyOCPDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MyOCPDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MyOCPDatabaseSettings.Value.DatabaseName);

        _dbCollection = mongoDatabase.GetCollection<Enfant>(
            MyOCPDatabaseSettings.Value.EnfantsCollectionName);

    }

    public async Task<List<Enfant>> GetAsync() =>
        await _dbCollection.Find(_ => true).ToListAsync();

    public async Task<Enfant?> GetAsync(string id) =>
        await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Enfant newEnfant) =>
        await _dbCollection.InsertOneAsync(newEnfant);

    public async Task UpdateAsync(string id, Enfant updatedEnfant) =>
        await _dbCollection.ReplaceOneAsync(x => x.Id == id, updatedEnfant);

    public async Task RemoveAsync(string id) =>
        await _dbCollection.DeleteOneAsync(x => x.Id == id);
}