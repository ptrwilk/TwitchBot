namespace TwitchBot;

public class DarkSoulsLogic
{
    private readonly DarkSouls _darkSouls;
    public event Action CharacterDied;

    private bool _alive = false;

    public DarkSoulsLogic(DarkSouls darkSouls)
    {
        _darkSouls = darkSouls;
        
        Task.Run(Work);
    }

    private void Work()
    {
        while (true)
        {
            Thread.Sleep(1000);

            try
            {
                var hp = _darkSouls.GetHp();

                if (_alive == false && hp > 0)
                {
                    _alive = true;
                }
                else if (_alive && hp == 0)
                {
                    //Died
                    _alive = false;
                    CharacterDied();
                }
            }
            catch (DarkSoulsNotOpenedException ex)
            {
                Console.WriteLine("DarkSouls is not opened");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled error {ex.Message}");
            }
        }
    }
}