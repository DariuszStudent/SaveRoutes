using System.Collections.Generic;
using System.IO;

namespace SaveRoutes.Core
{
    public class UserManager
    {
        public static IManager GetManager()
        {
            return new FileManager();
        }

        private List<User> Users { get; set; }
        public string fileName { get; set; } = "Users.txt";
        private IManager manager { get; set; } = GetManager();
        
        public UserManager()
        {
            Users = new List<User>();

            manager.AddUserToCTor(fileName, AddNewUser);            
        }

        public void AddNewUser(int id, string firstName, string lastName, bool shouldToSaveToFile = true)
        {
            var user = new User(id, firstName, lastName);

            Users.Add(user);

            if (shouldToSaveToFile) manager.AddUser(fileName, user);
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

            manager.RemoveItem(fileName, listUsers);
        }

        public List<string> ShowListUsers()
        {
            List<string> usersString = new List<string>();

            foreach (var user in Users)
            {
                var stringEdit = "Id: " + user.Id + ". " + user.FirstName + " " + user.LastName;
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
