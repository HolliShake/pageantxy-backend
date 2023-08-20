
using DOMAIN.model;

namespace APP.IServices;

public interface IScoreService : IGenericService<Score>
{

    public Task<ICollection<Score>> GetAllByJudgeId(string id);
    public Task<ICollection<IGrouping<Candidate, Score>>> GetAllScoreGroupByCandidateId();
}