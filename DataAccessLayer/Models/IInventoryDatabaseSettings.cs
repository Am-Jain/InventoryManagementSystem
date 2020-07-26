namespace DataAccessLayer.Models
{
    public interface IInventoryDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string FilePath { get; set; }

    }
}
