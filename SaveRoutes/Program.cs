using SaveRoutes.Core;
using System;

namespace SaveRoutes
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionView menuAction = new MenuActionView();
            SaveRoutesApp saveRoutesApp = new SaveRoutesApp();

            var exit = default(int);
            
            while (exit != 9)
            {
                Console.Clear();
                saveRoutesApp.IntroduceSaveRoutessApp();
                saveRoutesApp.ShowUserMonth();
                saveRoutesApp.ShowAllUsers();
                menuAction.ShowMenu();

                Console.Write("Wybrana opcja menu to: ");
                var userInput = Console.ReadKey();
                Console.WriteLine("\n");

                switch (userInput.KeyChar)
                {
                    case '1':
                        saveRoutesApp.ShowMonths();
                        saveRoutesApp.ChooseMonth();
                        break;
                    case '2':
                        saveRoutesApp.AddUser();
                        break;
                    case '3':
                        saveRoutesApp.RemoveUser();
                        break;
                    case '4':
                        saveRoutesApp.AddRoute();
                        break;
                    case '5':
                        saveRoutesApp.RemoveRoute();
                        break;
                    case '6':
                        saveRoutesApp.ShowAllRoutes();
                        Console.ReadKey();
                        break;
                    case '9':
                        exit = 9;
                        break;


                    default:
                        Console.WriteLine("Błąd, wprowadzona została zła dana.\n");
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }

                
            }
        }
    }
}
