using dotnet_apps.Models;
using dotnet_apps.Presenters;
using dotnet_apps.ViewModels;

namespace dotnet_apps.Views;

public partial class MainView : Form, IView
{
    private readonly MainPresenter _presenter;

    public MainView()
    {
        InitializeComponent();

        _presenter = new MainPresenter(this);
    }

    protected override async void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        await _presenter.SyncDbClicked();
    }

    public void FillUsers(IEnumerable<UserViewModel> userViewModels)
    {
        bindingSource1.DataSource = userViewModels;
    }

    public void ResetBinding()
    {
        if (InvokeRequired)
        {
            Invoke(() =>
            {
                bindingSource1.ResetBindings(false);
                bindingSource2.ResetBindings(false);
            });
        }
        else
        {
            bindingSource1.ResetBindings(false);
            bindingSource2.ResetBindings(false);
        }
    }

    public void SetState(MainViewModel mainViewModel)
    {
        bindingSource2.DataSource = mainViewModel;
    }

    private async void button1_Clicked(object sender, EventArgs e)
    {
        await _presenter.SyncDbClicked();
    }
}
