using TwitchBot.Data;
using TwitchBot.Models;

namespace TwitchBot.Factories;

public class DataContextFactory
{
    public DataContext Create(DatabaseType type)
    {
        switch (type)
        {
            case DatabaseType.DeadAlive:
                return new DataContext("DeadAlive");
        }
        
        throw new KeyNotFoundException($"Type {type} not supported");
    }
}