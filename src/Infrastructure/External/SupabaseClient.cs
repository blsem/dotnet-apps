namespace dotnet_apps.Infrastructure.External;

public class SupabaseClient
{
    private static volatile Supabase.Client? _instance;
    private static object Lock = new object();
    private static string? url = Environment.GetEnvironmentVariable("SUPABASE_URL");
    private static string? key= Environment.GetEnvironmentVariable("SUPABASE_KEY");

    public static Supabase.Client Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Supabase.Client(url!, key!, new Supabase.SupabaseOptions { AutoConnectRealtime = true, });
                        _instance.InitializeAsync();
                    }
                }
            }

            return _instance;
        }
    }
}