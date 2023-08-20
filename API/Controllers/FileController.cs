using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly ConfigurationManager _config;

    public FileController(ConfigurationManager configuration)
    {
        _config = configuration;  
    }

    [HttpPost("upload", Name = "UploadFile")]
    public async Task<ActionResult> UploadFile(IFormFile file)
    {
        var result = await Uploader.WriteFile(_config, file);

        return (result != null) ? Ok(result) : BadRequest();
    }
}


class Uploader
{
    public static async Task<string> WriteFile(ConfigurationManager configuration, IFormFile file)
    {
        var names = file.FileName.Split('.');
        var extension = "." + names[^1];

        string fileName;
        try
        {
            fileName = Path.GetRandomFileName() + $"-{Guid.NewGuid()}" + extension;
            var targetPath = Path.Combine(configuration["File:Location"], configuration["File:Destination"]);

       
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);

                // Store
                var path = Path.Combine(targetPath, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            else
            {
                // Store
                var path = Path.Combine(targetPath, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR >>>>>>>" + e.ToString());
            return null;
        }

        return fileName;
    }
}