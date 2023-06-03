using CollabsApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CollabsApi.Services;

public class CollabService
{
    private readonly IMongoCollection<Collab> _dbCollection;



    public CollabService(
        IOptions<MyOCPDatabaseSettings> MyOCPDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            MyOCPDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            MyOCPDatabaseSettings.Value.DatabaseName);

        _dbCollection = mongoDatabase.GetCollection<Collab>(
            MyOCPDatabaseSettings.Value.CollabsCollectionName);

    }

    public async Task<List<Collab>> GetAsync() =>
        await _dbCollection.Find(_ => true).ToListAsync();

    public async Task<Collab?> GetAsync(string id) =>
        await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Collab newCollab) =>
        await _dbCollection.InsertOneAsync(newCollab);

    public async Task UpdateAsync(string id, Collab updatedCollab) =>
        await _dbCollection.ReplaceOneAsync(x => x.Id == id, updatedCollab);

    public async Task RemoveAsync(string id) =>
        await _dbCollection.DeleteOneAsync(x => x.Id == id);
}