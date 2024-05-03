using System.ComponentModel.DataAnnotations;

namespace TwitchBot.Data.Entities;

public class ResultEntity
{
    [Key]
    public int ResultId { get; set; }
    public int ModuleOffset { get; set; }
    public int? Offset1 { get; set; }
    public int? Offset2 { get; set; }
    public int? Offset3 { get; set; }
    public int? Offset4 { get; set; }
    public int? Offset5 { get; set; }
    public int? Offset6 { get; set; }
    public int? Offset7 { get; set; }
}