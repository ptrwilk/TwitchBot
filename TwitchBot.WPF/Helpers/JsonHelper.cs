using System;
using System.IO;
using System.Text.Json;

namespace TwitchBot.WPF.Helpers;

public static class JsonHelper
{
    private static string WithExt(string name) => $"{name}.json";
    public static T? Read<T>(string name)
    where T : new()
    {
        var jsonString = File.ReadAllText(WithExt(name));

        try
        {
            var res = JsonSerializer.Deserialize<T>(jsonString);

            return res;
        }
        catch (Exception e)
        {
            return new T();
        }
    }

    public static void Save<T>(T t, string name)
    {
        var jsonString = JsonSerializer.Serialize(t);
        
        File.WriteAllText(WithExt(name), jsonString);
    }

    public static void TryCreate(string name)
    {
        if (!File.Exists(WithExt(name)))
        {
            File.Create(WithExt(name));
        }
    }
}