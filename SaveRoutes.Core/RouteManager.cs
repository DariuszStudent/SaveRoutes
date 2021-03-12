using System.Collections.Generic;
using System.IO;

namespace SaveRoutes.Core
{
    public class RouteManager
    {
        public static IManager GetManager()
        {
            return new FileManager();
        }

        private List<Route> Routes { get; set; }
        private string fileName { get; set; } = "routes.txt";
        private IManager manager { get; set; } = GetManager();

        public RouteManager()
        {
            Routes = new List<Route>();

            manager.AddRouteToCTor(fileName, AddNewRoute);
        }

        public void AddNewRoute(int id, string container, string route, string shipping, string date, bool shouldSaveToFile = true)
        {
            Route newRoute = new Route(id, container, route, shipping, date);

            Routes.Add(newRoute);

            if (shouldSaveToFile) manager.AddRoute(fileName, newRoute);
        }

        public void RemoveRoute(string userInput, bool shouldSaveToFile = true)
        {
            foreach (var route in Routes)
            {
                if (userInput == route.Id.ToString() || userInput == route.Container)
                {
                    Routes.Remove(route);
                    break;
                }
            }

            if (shouldSaveToFile)
            {
                var routesToSave = new List<string>();

                foreach (var route in Routes)
                {
                    routesToSave.Add(route.ToString());
                }

                manager.RemoveItem(fileName, routesToSave);
            }
        }

        public List<string> ShowAllRoutes()
        {
            List<string> routesToShow = new List<string>();

            foreach (var route in Routes)
            {
                var stringEdit = $"{route.Id}.   |   {route.Container}   |   {route.UserRoute}   |   {route.Shipping}   |   {route.Date}";
                routesToShow.Add(stringEdit);
            }

            return routesToShow;
        }

        public bool CheckID(int userID)
        {
            for (var i = 0; i < Routes.Count; i++)
            {
                if (Routes[i].Id == userID)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
