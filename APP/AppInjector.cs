
using APP.Mapper;
using CQI.APPLICATION.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace APP;

public class AppInjector
{
    public static void Inject(IServiceCollection services, ConfigurationManager configuration)
    {
        // AutoMaper
        services.AddAutoMapper(
            typeof(AuthMapper),
            typeof(EventMapper),
            typeof(ContestMapper),
            typeof(CandidateMapper),
            typeof(RegisterMapper),
            typeof(ScoreMapper),
            typeof(LogMapper),
            typeof(UserMapper)
        );

        // Jwt
        var cfg = new JwtTokenConfig(
            configuration["Jwt:SecretKey"],
            configuration["Jwt:Issuer"],
            configuration["Jwt:Audience"]
        );

        services.AddSingleton(cfg);

        services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
        services.AddHostedService<JwtRefreshTokenCache>();

        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.RequireHttpsMetadata = true;
            option.SaveToken = true;
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(cfg.SecurityKey),
                ValidIssuer = cfg.Issuer,
                ValidAudience = cfg.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(0)
            };

            option.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];

                    // If the request is for our hub...
                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        // Read the token out of the query string
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };
        });
    }
}