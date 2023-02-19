using dotnet_apps.Infrastructure.External;
using dotnet_apps.Models;
using Supabase.Realtime.PostgresChanges;

namespace dotnet_apps.Repositories;

public class UserRepository
{
    private readonly List<User> _users;
    private static volatile UserRepository? _instance;
    private static object Lock = new object();

    public UserRepository()
    {
        _users = new List<User>();
    }

    public static UserRepository Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserRepository();
                    }
                }
            }

            return _instance;
        }
    }

    public List<User> GetUsers() => _users;

    public async Task<List<User>> LoadUsersAsync()
    {
        var result = await SupabaseClient.Instance
            .From<User>()
            .Select(x => new object[] { x.Id, x.Name, x.Comment, x.Data })
            .Get();

        _users.Clear();
        _users.AddRange(result.Models);

        return _users;
    }

    internal async Task Subscribe(Action<object, PostgresChangesEventArgs> handler)
    {
        await SupabaseClient.Instance
            .From<User>()
            .On(Supabase.Client.ChannelEventType.Update, handler);
    }

    internal async Task Unsubscribe()
    {
        var channel = await SupabaseClient.Instance
            .From<User>()
            .On(Supabase.Client.ChannelEventType.Update, (sender, args) => { });

        channel.Unsubscribe();
    }
}