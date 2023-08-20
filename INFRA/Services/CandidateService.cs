
using APP.IServices;
using DOMAIN.model;
using INFRA.Data;

namespace INFRA.Services;
public class CandidateService : GenericService<Candidate>, ICandidateService
{
    public CandidateService(AppDbContext context) : base(context)
    {
    }
}