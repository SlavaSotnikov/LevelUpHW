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
            Display battle = BL.CreateButtleDisplay();
            Cartridge shipMag = BL.CreateCartridge(10);
            
            Swarm enemies = BL.CreateSwarm(10);

            UI.ShowBattleMenu(ref battle);

            do
            {
                UI.ShowHideSpacecraft(ship);

                BL.ProduceEnemies(ref enemies);

                UI.PrintEnemies(ref enemies);

                ship.oldCoordinateX = ship.сoordinateX;
                ship.oldCoordinateY = ship.сoordinateY;

                // Get new coordinates or an event.
                userEvent = UI.AskConsole();

                BL.EventProcessing(ref ship, borders, userEvent, ref shipMag);

                BL.CheckAllObjects(ref shipMag, borders);

                UI.PrintShots(ref shipMag);

                //BL.CleanStructures(ref shipMag);

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