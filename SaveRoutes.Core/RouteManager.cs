using System.Collections.Generic;
using System.IO;

namespace SaveRoutes.Core
{
    public class RouteManager
    {
        private List<Route> Routes { get; set; }

        private string FileName { get; set; } = "routes.txt";

        public RouteManager()
        {
            Routes = new List<Route>();

            if (!File.Exists(FileName)) return;

            var fileLines = File.ReadAllLines(FileName);
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');

                if (int.TryParse(lineItems[0], out var id))
                {
                    AddNewRoute(id, lineItems[1], lineItems[2], lineItems[3], lineItems[4], false);
                }               
            }
        }

        public void AddNewRoute(int id, string container, string route, string shipping, string date, bool shouldSaveToFile = true)
        {
            Route newRoute = new Route()
            {
                Id = id,
                Container = container,
                UserRoute = route,
                Shipping = shipping,
                Date = date,
            };

            Routes.Add(newRoute);

            if (shouldSaveToFile)
            {
                File.AppendAllLines(FileName, new List<string> { newRoute.ToString() });
            }
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

                File.Delete(FileName);
                File.WriteAllLines(FileName, routesToSave);
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
