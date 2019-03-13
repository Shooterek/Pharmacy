namespace Pharmacy.Infrastructure.EF
{
    public class SqlSettings
    {
        public string ConnectionString { get; set; }
        public bool InMemory { get; set; }
        public string InMemoryDatabaseName { get; set; }
    }
}