namespace dotnet_apps.Models;

public class MainModel
{
    public bool Sync { get; set; } = false;
    public Color LabelBackColor { get; set; } = Color.AliceBlue;
    public string LabelText { get; set; } = "Ready";
}