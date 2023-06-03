namespace Mobility.Models;

public class MobilityDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string MobilityCollectionName { get; set; } = null!;
}