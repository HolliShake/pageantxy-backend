using APP.IServices;
using DOMAIN.model;
using INFRA.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRA.Services;

public class LogService : GenericService<Log>, ILogService
{
    public LogService(AppDbContext context) : base(context)
    {
    }

    public new async Task<Log?> GetAsync(int id)
    {
        return await _dbModel.Include(log => log.Contest).Include(log => log.User).Where(log => log.Id == id).FirstOrDefaultAsync();
    }

    public new async Task<ICollection<Log>> GetAllAsync()
    {
        return await _dbModel.Include(log => log.Contest).Include(log => log.User).ToListAsync();
    }

    public async Task<ICollection<Log>> GetAllByJudgeId(string id)
    {
        return await _dbModel.Include(log => log.Contest).Include(log => log.User).Where(log => log.UserId.Equals(id)).ToListAsync();
    }
}