using System;
using System.Collections.Generic;
using System.IO;

namespace SaveRoutes.Core
{
    public class FileManager
    {      
        public void AddUserFileToCTor(string fileName, Action<int, string, string, bool> AddNewUser)
        {
            if (!File.Exists(fileName)) return;

            var fileLines = File.ReadAllLines(fileName);
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');
                if (int.TryParse(lineItems[0], out var id))
                {
                    AddNewUser(id, lineItems[1], lineItems[2], false);
                }
            }
        }

        public void AddRouteFileToCTor(string fileName, Action<int, string, string, string, string, bool> AddNewRoute)
        {
            if (!File.Exists(fileName)) return;

            var fileLines = File.ReadAllLines(fileName);
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');

                if (int.TryParse(lineItems[0], out var id))
                {
                    AddNewRoute(id, lineItems[1], lineItems[2], lineItems[3], lineItems[4], false);
                }
            }
        }

        public void AddUser(string fileName, User user)
        {
            File.AppendAllLines(fileName, new List<string> { user.ToString() });
        }

        public void AddRoute(string fileName, Route route)
        {
            File.AppendAllLines(fileName, new List<string> { route.ToString() });
        }

        public void RemoveItem(string fileName, List<string> list)
        {
            File.Delete(fileName);
            File.WriteAllLines(fileName, list);
        }
    }
}
