using System.Runtime.InteropServices;

namespace TwitchBot.Core;

public enum Keys
{
    Num_8,
    Num_5,
    Num_2,
    Num_0
}

public class KeyReader
{
    [DllImport("user32.dll")]
    public static extern int GetAsyncKeyState(Int32 i);

    private IDictionary<Keys, int> _dictionary = new Dictionary<Keys, int>
    {
        { Keys.Num_8 , 0x68}, { Keys.Num_5 , 0x65},  { Keys.Num_2 , 0x62},  { Keys.Num_0 , 0x60}
    };

    private static int LeftCtrl = 0x11;

    public event Action<bool,Keys> KeyPressed = null!;
    private bool _pressed = false;

    public void Start()
    {
        Thread kb = new Thread(Work);
        kb.Start();
    }

    private void Work()
    {
        while (true)
        {
            Thread.Sleep(10);

            //End 

            bool isPressed = false;
            foreach (var dict in _dictionary)
            {
                var keyPressed = IsPressed(dict.Value);
                var ctrlPressed = IsPressed(LeftCtrl);

                if (keyPressed)
                {
                    isPressed = true;
                }

                if (isPressed && _pressed == false)
                {
                    _pressed = true;
                    KeyPressed(ctrlPressed, dict.Key);
                    break;
                }
            }

            if (isPressed == false && _pressed)
            {
                _pressed = false;
            }
        }
    }

    private bool IsPressed(int value)
    {
        var key = GetAsyncKeyState(value);

        return (key & 0x8000) != 0;
    }

    public void Stop()
    {
    }
}