

using APP.IServices;
using DOMAIN.model;
using INFRA.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRA.Services;

public class RegisterService : GenericService<Register>, IRegisterService
{
    public RegisterService(AppDbContext context) : base(context)
    {
    }

    public new async Task<ICollection<Register>> GetAllAsync()
    {
        return await _dbModel.Include(r => r.Candidate).Include(r => r.Contest).ToListAsync();
    }

    public new async Task<Register?> GetAsync(int id)
    {
        return await _dbModel.Include(r => r.Candidate).Include(r => r.Contest).Where(r => r.Id == id).FirstOrDefaultAsync();
    }
}