namespace CollabsApi.Models;

public class MyOCPDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string CollabsCollectionName { get; set; } = null!;

    public string EnfantsCollectionName { get; set; } = null!;

    public string DemandesCollectionName { get; set; } = null!;
}
