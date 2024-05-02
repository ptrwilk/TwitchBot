using Swed64;

namespace TwitchBot;

public class DarkSoulsNotOpenedException : Exception
{
}

public class DarkSouls
{
    private static readonly int[] HpAddress = { 0x01C77E50, 0x68, 0x7B8, 0x70, 0x60, 0x468, 0x578, 0x14 };
    private static readonly int[] LoadAddress = { 0x01C8B038, 0x18, 0x458, 0x38, 0x0, 0x10, 0x10, 0x2B4 };
    private static readonly int[] GameAddress = { 0x1C7498C };
    private static readonly int[] DeadAliveAddress = { 0x01C7DD38, 0xEC0, 0x90, 0x98, 0x30, 0x20, 0x28, 0x50C };


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

    public bool InGame()
    {
        var swed = CreateSwed();

        var moduleBase = GetModuleBase(swed);

        var res = swed.ReadInt(moduleBase, GameAddress[0]);

        return res == 1;
    }

    public bool IsDead()
    {
        var pointer = ReadPointer(DeadAliveAddress, out var swed);
        
        var value = swed.ReadInt(pointer);

        return value != 1;
    }

    private Swed CreateSwed()
    {
        try
        {
            return new Swed("DarkSoulsRemastered");
        }
        catch (Exception e)
        {
            throw new DarkSoulsNotOpenedException();
        }
    }

    private IntPtr GetModuleBase(Swed swed)
    {
        return swed.GetModuleBase("DarkSoulsRemastered.exe");
    }

    private IntPtr ReadPointer(int[] address, out Swed swed)
    {
        swed = CreateSwed();

        var moduleBase = GetModuleBase(swed);

        var pointer = swed.ReadPointer(moduleBase, address[0], address[1], address[2], address[3], address[4],
            address[5], address[6]) + address[7];

        return pointer;
    }
}