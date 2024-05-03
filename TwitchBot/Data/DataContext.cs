using Microsoft.EntityFrameworkCore;
using TwitchBot.Data.Entities;

namespace TwitchBot.Data;

public class DataContext : DbContext
{
    private string _name { get; set; }
    public DbSet<ResultEntity> Results { get; set; }
    
    public DataContext(string name)
    {
        _name = name;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"data source = Data/Databases/{_name}.sqlite");
    }
}