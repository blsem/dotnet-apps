using dotnet_apps.ViewModels;

namespace dotnet_apps.Views;

public interface IView
{
    void FillUsers(IEnumerable<UserViewModel> userViewModels);
    void ResetBinding();
    void SetState(MainViewModel mainViewModel);
}
