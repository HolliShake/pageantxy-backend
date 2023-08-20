using APP.IServices;
using INFRA.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRA.Services;
public class GenericService<TModel> : IGenericService<TModel> where TModel : class
{
    protected readonly AppDbContext _dbContext;
    protected readonly DbSet<TModel> _dbModel;

    public GenericService(AppDbContext context)
    {
        _dbContext = context;
        _dbModel = _dbContext.Set<TModel>();
    }

    public async Task<ICollection<TModel>> GetAllAsync()
    {
        return await _dbModel.ToListAsync();
    }

    public async Task<TModel?> GetAsync(int id)
    {
        return await _dbModel.FindAsync(id);
    }

    public async Task<TModel?> GetAsync(string id)
    {
        return await _dbModel.FindAsync(id);
    }

    public async Task<bool> CreateAsync(TModel newEntry)
    {
        await _dbModel.AddAsync(newEntry);
        return await SaveChanges(); 
    }

    public async Task<bool> UpdateAsync(TModel updatedEntry)
    {
       _dbModel.Update(updatedEntry);
        return await SaveChanges();
    }

    public async Task<bool> DeleteAsync(TModel existingEntry)
    {
        _dbModel.Remove(existingEntry);
        return await SaveChanges();
    }


    protected async Task<bool> SaveChanges()
    {
        return (await _dbContext.SaveChangesAsync()) > 0;
    }
}