using System.Collections.Generic;
using System.IO;

namespace SaveRoutes.Core
{
    public class UserManager
    {
        private List<User> Users { get; set; }

        private string Filename { get; set; } = "users.txt";

        public UserManager()
        {
            Users = new List<User>();

            if (!File.Exists(Filename)) return;

            var fileLines = File.ReadAllLines(Filename);           
            foreach (var line in fileLines)
            {
                var lineItems = line.Split(';');
                if (int.TryParse(lineItems[0], out var id))
                {
                    AddNewUser(id, lineItems[1], lineItems[2], false);
                }    
            }
        }

        public void AddNewUser(int id, string name, string surname, bool shouldToSaveToFile = true)
        {
            var user = new User
            { 
                Id = id, 
                Name = name, 
                Surname = surname 
            };

            Users.Add(user);

            if (shouldToSaveToFile) File.AppendAllLines(Filename, new List<string> { user.ToString() });
        }

        public void RemoveUser(int id)
        {
            for (var i = 0; i < Users.Count; i++)
            {
                if (Users[i].Id == id)
                {
                    Users.Remove(Users[i]);
                    break;
                }
            }

            var listUsers = new List<string>();
            foreach (var user in Users)
            {
                listUsers.Add(user.ToString());
            }

            File.Delete(Filename);
            File.WriteAllLines(Filename, listUsers);
        }

        public List<string> ShowListUsers()
        {
            List<string> usersString = new List<string>();

            foreach (var user in Users)
            {
                var stringEdit = "Id: " + user.Id + ". " + user.Name + " " + user.Surname;
                usersString.Add(stringEdit);
            }

            return usersString;
        }

        public bool CheckID(int userID)
        {
            for (var i = 0; i < Users.Count; i++)
            {
                if (Users[i].Id == userID)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
