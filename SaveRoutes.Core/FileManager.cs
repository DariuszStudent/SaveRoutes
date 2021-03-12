using System;
using System.Collections.Generic;
using System.IO;

namespace SaveRoutes.Core
{
    public class FileManager : IManager
    {
        private string fileNameRoute { get; set; } = "routes.txt";
        public string fileNameUser { get; set; } = "Users.txt";

        public void AddUserToCTor(Action<int, string, string, bool> AddNewUser)
        {
            if (!File.Exists(fileNameUser)) return;

            var fileLines = File.ReadAllLines(fileNameUser);
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');
                if (int.TryParse(lineItems[0], out var id))
                {
                    AddNewUser(id, lineItems[1], lineItems[2], false);
                }
            }
        }

        public void AddRouteToCTor(Action<int, string, string, string, string, bool> AddNewRoute)
        {
            if (!File.Exists(fileNameRoute)) return;

            var fileLines = File.ReadAllLines(fileNameRoute);
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');

                if (int.TryParse(lineItems[0], out var id))
                {
                    AddNewRoute(id, lineItems[1], lineItems[2], lineItems[3], lineItems[4], false);
                }
            }
        }

        public void AddUser(User user)
        {
            File.AppendAllLines(fileNameUser, new List<string> { user.ToString() });
        }

        public void AddRoute(Route route)
        {
            File.AppendAllLines(fileNameRoute, new List<string> { route.ToString() });
        }

        public void RemoveRoute(List<string> list)
        {
            File.Delete(fileNameRoute);
            File.WriteAllLines(fileNameRoute, list);
        }

        public void RemoveUser(List<string> list)
        {
            File.Delete(fileNameUser);
            File.WriteAllLines(fileNameUser, list);
        }
    }
}
