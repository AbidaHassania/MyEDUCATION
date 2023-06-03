namespace miseAjour.Models;

public class UpdateDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string UpdateCollectionName { get; set; } = null!;
}