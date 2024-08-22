using Config.Options;
using Shared.Constants;

namespace API.Setup;

public static class OptionsSetupExtension
{
    public static void SetupServiceOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ApplicationOptions>()
                .Bind(configuration.GetSection(ApplicationOptions.Key));
    }
}