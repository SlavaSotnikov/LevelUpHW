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

            //

            Actions userEvent; // Do we have to hand 'userDirection' to 'UI.AskConsole()'?
            Display battle = BL.CreateButtleDisplay();
            Cartridge shipMag = BL.CreateCartridge(10);

            //TODO: It must have an instance after the spacebar was pressed.
            

            UI.ShowBattleMenu(ref battle);

            do
            {
                UI.ShowHideSpacecraft(ship);

                ship.oldCoordinateX = ship.сoordinateX;
                ship.oldCoordinateY = ship.сoordinateY;

                // Get new coordinates or an event.
                userEvent = UI.AskConsole();

                BL.EventProcessing(ref ship, borders, userEvent, ref shipMag);

                UI.PrintShots(ref shipMag);

                BL.CheckAllObjects(ref shipMag, borders);

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
