namespace MenuDLL
{
    internal class Text
    {
        public static string Title { get; private set; }

        public static string About { get; private set; }

        public static string Introduction { get; private set; }

        public static string Dialogue { get; private set; }

        public static string[] LightShip { get; private set; }

        public static string[] HeavyShip { get; private set; }

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

            Introduction = "AD2030. Human scientists discovered that they are not the\n" +
                "only intelligence in the galaxy....\n" +

                "\nAD2035. Human and aliens had their first contact....\n" +

                "\nYet this contact turned out to be the beginning of alien invasion...\n" +

                "\nThey tried to slave earth and dried up the resource of humanity \n" +
                "until the extinction of human civilization...\n" +

                "\nHuman military suffers a unmeasurable loss and can not \n" +
                "afford an effective counterattack...\n" +

                "\nWhen most of people lose their faith to survive, \n" +
                "there are a few people willing to stand out \n" +
                "and sacriface themselves to protect the people they love...";

            Dialogue = "Captain: Greetings, fly leutenant. Report! What is your name?\n" +
            "Where are you come from?\n" +
            "Captain: Pick your ship.\n";

            LightShip = new string[5]
            {
               "    ▲    ",
               "    Ο    ",
               "  ║ Ο ║  ",
               "╱╲╲╲Λ╱╱╱╲",
               "  <╱╦╲>  "
            };

            HeavyShip = new string[5]
            {
              "    ▲    ",
              "   ╱Ο╲   ",
              "∩ ╱UKR╲ ∩",
              "╠═══Λ═══╣",
              " <╱*╦*╲> "
            };
        }
    }
}
