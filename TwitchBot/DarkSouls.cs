using Swed64;

namespace TwitchBot;

public class DarkSoulsNotOpenedException : Exception
{
}

public class DarkSouls
{
    private static readonly int[] HpAddress = { 0x01C77E50, 0x68, 0x7B8, 0x70, 0x60, 0x468, 0x578, 0x14 };
    private static readonly int[] LoadAddress = { 0x01C8B038, 0x18, 0x458, 0x38, 0x0, 0x10, 0x10, 0x2B4 };

    public int GetHp()
    {
        var pointer = ReadPointer(HpAddress, out var swed);

        var hp = swed.ReadInt(pointer);

        return hp;
    }

    public float GetLoad()
    {
        var pointer = ReadPointer(LoadAddress, out var swed);
        
        var load = swed.ReadFloat(pointer);

        return load;
    }

    private IntPtr ReadPointer(int[] address, out Swed swed)
    {
        try
        {
            swed = new Swed("DarkSoulsRemastered");
        }
        catch (Exception e)
        {
            throw new DarkSoulsNotOpenedException();
        }
        var moduleBase = swed.GetModuleBase("DarkSoulsRemastered.exe");

        var pointer = swed.ReadPointer(moduleBase, address[0], address[1], address[2], address[3], address[4],
            address[5], address[6]) + address[7];

        return pointer;
    }
}