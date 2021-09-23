namespace Menu
{
    internal static class Text
    {
        public static string About { get; private set; }

        static Text()
        {
            About = "This game was created by Slava Sotnikov.\n" +
                                  "It uses assets from http://patorjk.com.\n" +
                                "\nPress any key to return to the menu...";
        }
    }
}
