using dotnet_apps.Models;

namespace dotnet_apps.ViewModels;

public class MainViewModel
{
    private readonly MainModel _model;

    public MainViewModel(MainModel model) => _model = model;

    public MainModel Model { get => _model; }

    public bool Sync { get => _model.Sync; set => _model.Sync = value; }

    public string LabelText { get => _model.LabelText; set => _model.LabelText = value; }

    public Color LabelBackColor { get => _model.LabelBackColor; set => _model.LabelBackColor = value; }
}