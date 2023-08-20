

namespace APP.IServices;

public interface IGenericService <TModel>
{
    public Task<ICollection<TModel>> GetAllAsync();
    public Task<TModel?> GetAsync(int id);
    public Task<TModel?> GetAsync(string id);
    public Task<bool> CreateAsync(TModel newEntry);
    public Task<bool> UpdateAsync(TModel updatedEntry);
    public Task<bool> DeleteAsync(TModel existingEntry);
}
