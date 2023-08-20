

using DOMAIN.model;

namespace APP.IServices;
public interface ILogService : IGenericService<Log>
{
    public Task<ICollection<Log>> GetAllByJudgeId(string id);
}