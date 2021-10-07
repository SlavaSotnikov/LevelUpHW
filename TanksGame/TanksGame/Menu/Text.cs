namespace Menu
{
    internal class Text
    {
        public static string Title { get; private set; }

        public static string About { get; private set; }

        static Text()
        {
            About = "This game was created by Slava Sotnikov.\n" +
                                  "It uses assets from http://patorjk.com.\n" +
                                "\nPress any key to return to the menu...";

             Title = @"
                        _____                        _____                     _               
                       / ____|                      |_   _|                   | |              
                      | (___  _ __   __ _  ___ ___    | |  _ ____   ____ _  __| | ___ _ __ ___ 
                       \___ \| '_ \ / _` |/ __/ _ \   | | | '_ \ \ / / _` |/ _` |/ _ \ '__/ __|
                       ____) | |_) | (_| | (_|  __/  _| |_| | | \ V / (_| | (_| |  __/ |  \__ \
                      |_____/| .__/ \__,_|\___\___| |_____|_| |_|\_/ \__,_|\__,_|\___|_|  |___/
                             | |                                                               
                             |_|                                                               
                      ";
        }
    }
}
