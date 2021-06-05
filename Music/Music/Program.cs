using System;
using System.Media;

namespace Music
{
    class Program
    {
        static void Main()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer myPlayer = new SoundPlayer("AudioForVideo_Slava.wav");
                myPlayer.Load();
                myPlayer.PlayLooping();
            }

            Console.ReadKey();
            
        }
    }
}
