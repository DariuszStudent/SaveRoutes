using SaveRoutes.Core;
using System;

namespace SaveRoutes
{
    public class SaveRoutesApp
    {
        Helpers helpers = new Helpers();
        UserManager userManager = new UserManager();
        MonthManager monthManager = new MonthManager();
        RouteManager routeManager = new RouteManager();

        public void IntroduceSaveRoutessApp()
        {
            Console.WriteLine("Witam w aplikacji Zapisz Trasę. Ułatwia życie w zapisywaniu tras w pracy jako kierowca. \n");
        }

        public void ChooseMonth()
        {
            Console.Write("Wybierz miesiąc: ");
            var result = helpers.JustNumbersAndRange(1, 12);
            monthManager.UserMonth(result);
        }

        public void ShowMonths()
        {
            monthManager.ShowMonths();
        }

        public void AddUser()
        {
            Console.Write("Podaj id (1-10): ");
            var userId = helpers.JustNumbersAndRange(1, 10);
            while (userManager.CheckID(userId))
            {
                Console.WriteLine("Id nie może sie powtarzać, wprowadź jeszcze raz: ");
                userId = helpers.JustNumbersAndRange(1, 10);
            }
            Console.Write("Podaj imię: ");
            var userName = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            var userSurname = Console.ReadLine();

            userManager.AddNewUser(userId, userName, userSurname);
        }

        public void RemoveUser()
        {
            Console.WriteLine("Podaj numer ID uzytkownika którego chcesz usunąć: ");
            var userToRemove = helpers.JustNumbersAndRange(1, 10);
            userManager.RemoveUser(userToRemove);
        }

        public void ShowAllUsers()
        {
            var listUsers = userManager.ShowListUsers();

            foreach (var user in listUsers)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();
        }

        public void AddRoute()
        {
            Console.WriteLine("Podaj Id: ");
            var idRoute = helpers.JustNumbersAndRange(1, 200);
            while (routeManager.CheckID(idRoute))
            {
                Console.WriteLine("Id nie może sie powtarzać, wprowadź jeszcze raz: ");
                idRoute = helpers.JustNumbersAndRange(1, 10);
            }
            Console.WriteLine("Podaj numer Kontenera: ");
            var container = Console.ReadLine();
            while (container.Length != 11)
            {
                Console.WriteLine("Kontener musi posiadać 11 znaków");
                container = Console.ReadLine();
            }
            Console.WriteLine("Podaj trasę, skąd - dokąd: ");
            var route = Console.ReadLine();
            Console.WriteLine("Podaj nazwę spedycji: ");
            var shipping = Console.ReadLine();
            Console.WriteLine("Podaj dzień, np 01: ");
            var date = helpers.JustNumbersAndRange(1, 31);
            var dateAdd = date + ". " + monthManager.ActuallyMonthToPolish() + ". 2021r.";

            routeManager.AddNewRoute(idRoute, container, route, shipping, dateAdd);
        }    
        
        public void RemoveRoute()
        {
            ShowAllRoutes();
            Console.WriteLine("W celu usunięnia podaj numer kontenera lub Id Trasy: ");
            var userInput = Console.ReadLine();
            routeManager.RemoveRoute(userInput);
        }

        public void ShowAllRoutes()
        {
            Console.WriteLine("Twoje wpisane trasy to: ");
            var routes = routeManager.ShowAllRoutes();
            foreach (var route in routes)
            {
                Console.WriteLine(route);
            }
        }        

        public void ShowUserMonth()
        {
            Console.WriteLine($"Wybrany miesiąc: " + monthManager.ActuallyMonthToPolish());
        }
    }
}
