
using APP.IServices;
using DOMAIN.model;
using INFRA.Data;
using INFRA.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace INFRA;
public class InfraInjector
{
    public static void Inject(IServiceCollection services, ConfigurationManager configuration)
    {
        // Inject services
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IContestService, ContestService>();
        services.AddScoped<ICandidateService, CandidateService>();
        services.AddScoped<IScoreService, ScoreService>();
        services.AddScoped<IRegisterService, RegisterService>();
        services.AddScoped<ILogService, LogService>();

        // Identity
        services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider)
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            // Default Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;
            options.User.RequireUniqueEmail = true;
        });

        // Newton soft json
        services.AddControllers()
            .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
    }
}