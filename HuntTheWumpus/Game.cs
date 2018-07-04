using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XNAHuntTheWumpus
{
    class Game
    {
   
        static void Main(string[] args)
        {
            Map GameBoard;
            int[] adjacentRooms;

            Console.WriteLine("Welcome to Hunt the Wumpus!");
            GameBoard = new Map(); //init gameboard with given seed

            while (true) //game loop (update logic)
            {
                Console.WriteLine("\n---------------------------");
                GameBoard.CheckIfWumpusAwake();
                GameBoard.printHazards();
                adjacentRooms = GameBoard.getAdjacentRooms(GameBoard.player.pos);

                Console.WriteLine("Currently in room " + GameBoard.player.pos);
                Console.WriteLine("You can move to rooms: " + adjacentRooms[0] + " " + adjacentRooms[1] + " " + adjacentRooms[2]);
                Console.WriteLine("Or press A to shoot an arrow through 5 rooms");

                bool validInput = false;
                do
                {
                    Console.Write("Your input: ");
                    string input = Console.ReadLine();
                    switch (input) //handle player choice
                    {
                        case "A":
                            validInput = true;
                            if (GameBoard.player.arrows > 0)
                                ReadArrowRooms(GameBoard);
                            else //out of arrows
                            {
                                Console.WriteLine("Out of arrows. The Wumpus got you! YOU LOSE!");
                                GameBoard.ReplayGame();
                            }

                            break;

                        case "1": case "2": case "3": case "4":case "5":case "6":case "7":case "8":case "9":case "10": //if user entered a number between 1-20
                        case "11":case "12":case "13":case "14":case "15": case "16": case "17": case "18": case "19":
                        case "20":
                            //parse to int
                            int move = int.Parse(input);
                            //check if number is an adjacent room
                            if (adjacentRooms.Contains(move))
                            {
                                GameBoard.PlayerMove(move);
                                validInput = true;
                            }
                            else Console.WriteLine("Invalid room, you can only move to: " + adjacentRooms[0] + " " + adjacentRooms[1] + " " + adjacentRooms[2]);
                            break;

                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                } while (!validInput);
            }

        }

        private static void ReadArrowRooms(Map GameBoard)
        {
            Console.WriteLine("Enter 5 rooms for the arrows to go through: ");

            int arrowRoom1;
            int arrowRoom2;
            int arrowRoom3;
            int arrowRoom4;
            int arrowRoom5;
            string readLine;

            do
            {
                Console.Write("1: ");
                readLine = Console.ReadLine();
                if (int.TryParse(readLine, out arrowRoom1)) //parse int
                    if (arrowRoom1 > 0 && arrowRoom1 <= 20)
                        break;

                Console.WriteLine("Invalid room number."); //should not reach here if input is valid
            } while (true); //loop until valid input

            do
            {
                Console.Write("2: ");
                readLine = Console.ReadLine();
                if (int.TryParse(readLine, out arrowRoom2))
                    if (arrowRoom2 > 0 && arrowRoom2 <= 20 && arrowRoom2 != arrowRoom1) //check to make sure not same room
                        break;

                Console.WriteLine("Invalid room number.");
            } while (true); //loop until valid input

            do
            {
                Console.Write("3: ");
                readLine = Console.ReadLine();
                if (int.TryParse(readLine, out arrowRoom3))
                    if (arrowRoom3 > 0 && arrowRoom3 <= 20)
                        if (arrowRoom3 != arrowRoom1 && arrowRoom3 != arrowRoom2) //check to make sure not same room and not crooked
                            break;
                        else Console.WriteLine("Arrows are not that crooked! Please enter again");

                Console.WriteLine("Invalid room number.");
            } while (true); //loop until valid input

            do
            {
                Console.Write("4: ");
                readLine = Console.ReadLine();
                if (int.TryParse(readLine, out arrowRoom4))
                    if (arrowRoom4 > 0 && arrowRoom4 <= 20)
                        if (arrowRoom4 != arrowRoom2 && arrowRoom4 != arrowRoom3) //check to make sure not same room and not crooked
                            break;
                        else Console.WriteLine("Arrows are not that crooked! Please enter again");

                Console.WriteLine("Invalid room number.");
            } while (true); //loop until valid input

            do
            {
                Console.Write("5: ");
                readLine = Console.ReadLine();
                if (int.TryParse(readLine, out arrowRoom5))
                    if (arrowRoom5 > 0 && arrowRoom5 <= 20)
                        if (arrowRoom5 != arrowRoom3 && arrowRoom5 != arrowRoom4) //check to make sure not same room and not crooked
                            break;
                        else Console.WriteLine("Arrows are not that crooked! Please enter again");

                Console.WriteLine("Invalid room number.");
            } while (true); //loop until valid input

            GameBoard.ShootArrow(new int[] { arrowRoom1, arrowRoom2, arrowRoom3, arrowRoom4, arrowRoom5});
        }
    }
}
