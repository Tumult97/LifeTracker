using System.IO.Compression;
using API.Setup;
using Microsoft.AspNetCore.ResponseCompression;

namespace API;

public class Startup
{
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
        SetupConnectionStrings();
    }

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env)
    {
        app.SetupApp(env);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.SetupRequiredAppServices();
        services.SetupServiceOptions(_configuration);
    }

    private void SetupConnectionStrings()
    {
        //method is empty for now
    }
    
}



