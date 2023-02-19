using System.ComponentModel;
using dotnet_apps.Models;

namespace dotnet_apps.ViewModels;

public class UserViewModel
{
    private readonly User _user;

    public UserViewModel(User user) => _user = user;

    [Browsable(false)]
    public User User { get => _user; }

    public int Id { get => _user.Id; set => _user.Id = value; }

    public string Name { get => _user.Name; set => _user.Name = value; }

    public string Comment { get => _user.Comment; set => _user.Comment = value; }

    public string Data
    {
        get { return _user.Data?.ToString() ?? string.Empty; }
        set { _user.Data = value ?? string.Empty; }
    }
}