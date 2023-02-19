using dotnet_apps.Models;
using dotnet_apps.ViewModels;
using dotnet_apps.Views;

namespace dotnet_apps.Presenters;

public class MainPresenter
{
    private readonly IView _view;
    private readonly MainModel _model;
    private MainViewModel _mainViewModel;
    private IEnumerable<UserViewModel>? _userViewModels;

    public MainPresenter(IView view)
    {
        this._view = view;
        this._model = new MainModel();
        _mainViewModel = new MainViewModel(_model);
        _view.SetState(_mainViewModel);
    }

    public async Task SyncDbClicked()
    {
        _mainViewModel.Sync = !_mainViewModel.Sync;
        if (_mainViewModel.Sync)
        {
            _mainViewModel.LabelBackColor = Color.Orange;
            _mainViewModel.LabelText = "Sync";
        }
        else
        {
            _mainViewModel.LabelBackColor = Color.AliceBlue;
            _mainViewModel.LabelText = "Ready";
        }
        _view.ResetBinding();
        if (_mainViewModel.Sync)
        {
            var users = await Repositories.UserRepository.Instance.LoadUsersAsync();
            _userViewModels = GetUserViewModels(users);
            _view.FillUsers(_userViewModels);

            await Subscribe();
        }
        else
        {
            await Unsubscribe();
        }
    }

    private async Task Subscribe()
    {
        await Repositories.UserRepository.Instance.Subscribe((sender, args) =>
            {
                if (args?.Response?.Model<User>() is not { } target) { return; }
                if (_userViewModels!.Where(i => i.Id == target.Id).SingleOrDefault() is not { } updating) { return; }

                updating.Name = target.Name;
                updating.Comment = target.Comment;
                updating.Data = target.Data?.ToString() ?? string.Empty;
                _view.ResetBinding();
            });
    }

    private async Task Unsubscribe()
    {
        await Repositories.UserRepository.Instance.Unsubscribe();
    }

    private IEnumerable<UserViewModel> GetUserViewModels(IEnumerable<User> users)
    {
        return users.Select(i => new UserViewModel(i)).OrderBy(i => i.Id);
    }
}