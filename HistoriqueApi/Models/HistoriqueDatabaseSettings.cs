namespace HistoriqueApi.Models;

public class HistoriqueDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string HistoriqueCollectionName { get; set; } = null!;
}