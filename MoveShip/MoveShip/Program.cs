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
            Cartridge shipMag = BL.CreateCartridge(20);
            Swarm enemies = BL.CreateSwarm(5);
            Fly enemy = BL.CreateFly();

            do
            {
                UI.ShowBattleMenu(ref battle); //TODO: BL vs UI

                UI.ShowHideSpacecraft(ship);

                ship.oldCoordinateX = ship.сoordinateX;
                ship.oldCoordinateY = ship.сoordinateY;

                UI.PrintEnemies(ref enemies);

                BL.ProduceEnemies(ref enemies, ref enemy);

                userEvent = UI.AskConsole();    // Get new coordinates or an event.

                BL.EventProcessing(ref ship, borders, userEvent, ref shipMag);

                UI.PrintShots(ref shipMag);

                BL.CleanDataStructures(ref enemies, ref shipMag);

                BL.CheckAllObjects(ref shipMag, ref enemies, ref battle, borders);

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