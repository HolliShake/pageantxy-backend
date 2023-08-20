using APP.IServices;
using DOMAIN.model;
using INFRA.Data;

namespace INFRA.Services;

public class ContestService : GenericService<Contest>, IContestService
{
    public ContestService(AppDbContext context) : base(context)
    {
    }
}