using APP.IServices;
using DOMAIN.model;
using INFRA.Data;

namespace INFRA.Services;

public class UserService : GenericService<User>, IUserService
{
    public UserService(AppDbContext context) : base(context)
    {
    }
}