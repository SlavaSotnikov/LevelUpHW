using System;
using System.Text;

namespace MoveShip
{
    class Program
    {
        /// <summary>
        /// Allows a user to run the Spaceship.
        /// </summary>
        static void RunSpaceship(GameField borders, Spacecraft ship)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            Actions userEvent; // Do we have to hand 'userDirection' to 'UI.AskConsole()'?
            Display battle = UI.CreateButtleDisplay();
            Cartridge shipMag = BL.CreateCartridge(16);
            Swarm enemies = BL.CreateSwarm(5);

            do
            {
                UI.ShowBattleMenu(ref battle);

                UI.ShowHideSpacecraft(ship);

                UI.PrintEnemies(ref enemies);



                BL.ProduceEnemies(ref enemies);

                

                ship.oldCoordinateX = ship.сoordinateX;
                ship.oldCoordinateY = ship.сoordinateY;

                // Get new coordinates or an event.
                userEvent = UI.AskConsole();

                BL.EventProcessing(ref ship, borders, userEvent, ref shipMag);

                UI.PrintShots(ref shipMag);

                

                BL.CheckAllObjects(ref shipMag, ref enemies, borders, battle);

                

            } while (userEvent != Actions.Exit);
        }

        static void Main()
        {
            UI.SetBufferSize();

            GameField borders = UI.SetGameFieldBorders();

            Spacecraft ship = UI.AskShipModel();

            RunSpaceship(borders, ship);
        }
    }
}