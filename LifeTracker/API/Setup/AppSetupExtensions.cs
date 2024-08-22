using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace API.Setup;

public static class AppSetupExtensions
{
    public static void SetupRequiredAppServices(this IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
            options.EnableForHttps = true;
        });
        services.Configure<GzipCompressionProviderOptions>(
            options => options.Level = CompressionLevel.Fastest
        );

        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAnyCorsPolicy",
                builder =>
                    builder
                        .WithOrigins(
                            "http://localhost:4200",
                            "https://localhost:4200",
                            "http://127.0.0.1:4200",
                            "https://127.0.0.1:4200"
                        )
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
            );
        });
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}