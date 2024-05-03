using System.Collections.Generic;
using System.Linq;
using TwitchBot.WPF.Helpers;
using TwitchBot.WPF.Models;

namespace TwitchBot.WPF.Services;

public static class ResultsService
{
    public static void Init()
    {
        JsonHelper.TryCreate(Consts.Results);

        var bosses = JsonHelper.Read<List<string>>(Consts.Bosses);
        var results = JsonHelper.Read<List<ResultModel>>(Consts.Results);

        foreach (var boss in bosses)
        {
            if (results.All(x => x.Boss != boss))
            {
                results.Add(new ResultModel
                {
                    Boss = boss,
                    Rips = 0
                });
            }
        }
        
        JsonHelper.Save(results, Consts.Results);
    }
    
    public static ResultModel[] GetAll()
    {
        var results = JsonHelper.Read<List<ResultModel>>(Consts.Results)!.ToArray();
        
        return results;
    }

    public static void Update(ResultModel model)
    {
        var results = GetAll();

        var result = results.First(x => x.Boss == model.Boss);
        result.Rips = model.Rips;
        
        JsonHelper.Save(results, Consts.Results);
    }
}