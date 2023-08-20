using API;
using APP;
using CQI.INFRA.Hubs;
using INFRA;
using INFRA.Hubs;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Protocols;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add Configuration
builder.Services.AddSingleton(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Infrea dependency injection
InfraInjector.Inject(builder.Services, builder.Configuration);

// App dependency injection
AppInjector.Inject(builder.Services, builder.Configuration);

// Api dependency injection
ApiInjector.Inject(builder.Services, builder.Configuration);


var app = builder.Build();

app.UseCors(x => x
    .WithOrigins("https://localhost:5173", "https://127.0.0.1:5173", "https://localhost:4000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithExposedHeaders("*")
    .SetIsOriginAllowed(_ => true) // allow any origin
    .AllowCredentials()); // allow credential

// Hosting
var path = Path.Combine(builder.Configuration["File:Location"], builder.Configuration["File:Destination"]);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(path),
    RequestPath = builder.Configuration["File:Request"]
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.MapHub<ContestHub>("/api/contesthub");
app.MapHub<RefreshHub>("/api/refreshhub");
app.Run();
