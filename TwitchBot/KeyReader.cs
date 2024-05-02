using System.Diagnostics;
using System.Runtime.InteropServices;

namespace TwitchBot;

public class KeyReader
{
    [DllImport("user32.dll")]
    public static extern int GetAsyncKeyState(Int32 i);

    public event Action KeyPressed = null!;
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
            var key = GetAsyncKeyState(0x23);

            if (key == 32768 && _pressed == false)
            {
                _pressed = true;
                KeyPressed();
            }
            else if(key == 0 && _pressed == true)
            {
                _pressed = false;
            }

        }
    }

    public void Stop()
    {
    }
}