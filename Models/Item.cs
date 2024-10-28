namespace NET_demo_ivs24.Models;

public class Item
{
    public int Id { get; set; }
    public required string Name { get; set; } //initialize the Name property without constructor.
    public double Price {get; set;}
}

// update your database schema after adding a new property
// dotnet ef migrations add <MigrationName>
// dotnet ef database update