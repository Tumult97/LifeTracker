namespace API;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            using var host = CreateHostBuilder(args).Build();
            host.Run();
        }
        catch (Exception ex)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Fatal Error occured:");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.ResetColor();
        }
        
        // var builder = WebApplication.CreateBuilder(args);
        //
        // // Add services to the container.
        //
        // builder.Services.AddControllers();
        //
        // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen();
        //
        // var app = builder.Build();
        //
        // // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
        //     app.UseSwagger();
        //     app.UseSwaggerUI();
        // }
        //
        // app.UseHttpsRedirection();
        //
        // app.UseAuthorization();
        //
        //
        // app.MapControllers();
        //
        // app.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) => 
        Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}