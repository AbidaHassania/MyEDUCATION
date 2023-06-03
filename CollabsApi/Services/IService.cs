using CollabsApi.Models;

namespace CollabsApi.Services;

public interface IService<T> where T: IEntity     // T represents the actual entity
{
    Task CreateAsync(T newT);
    Task<List<T>> GetAsync();
    Task<T?> GetAsync(string id);
    Task RemoveAsync(string id);
    Task UpdateAsync(string id, T updatedT);
}
