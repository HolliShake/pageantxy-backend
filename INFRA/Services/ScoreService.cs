

using APP.IServices;
using DOMAIN.model;
using INFRA.Data;
using Microsoft.EntityFrameworkCore;

namespace INFRA.Services;

public class ScoreService : GenericService<Score>, IScoreService
{
    public ScoreService(AppDbContext context) : base(context)
    {
    }

    public new async Task<ICollection<Score>> GetAllAsync()
    {
        return await _dbModel.Include(s => s.Contest).Include(s => s.Candidate).ToListAsync();
    }

    public async Task<ICollection<Score>> GetAllByJudgeId(string id)
    {
        return await _dbModel.Where(score => score.JudgeId.Equals(id)).ToListAsync();
    }

    public async Task<ICollection<IGrouping<Candidate, Score>>> GetAllScoreGroupByCandidateId()
    {
        return await _dbModel.Include(s => s.Candidate).Include(s => s.Judge).GroupBy(s => s.Candidate).ToListAsync();
    }
}