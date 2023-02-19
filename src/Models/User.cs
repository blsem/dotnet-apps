using Postgrest.Attributes;
using Postgrest.Models;

namespace dotnet_apps.Models;

[Table("users")]
public class User : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = string.Empty;
    [Column("comment")]
    public string Comment { get; set; } = string.Empty;
    [Column("data")]
    public object Data { get; set; } = new Object();
}