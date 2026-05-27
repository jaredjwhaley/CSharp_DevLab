namespace S2C13_LaunchSettings_ReverseProxyServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();

            // === NOTES ======================================================================================
            // - Please see LaunchSettings.json for notes on how to configure the reverse proxy server
            //   (IIS Express) to forward requests to Kestrel.
        }
    }
}
