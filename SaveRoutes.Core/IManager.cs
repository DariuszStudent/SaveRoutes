using System;
using System.Collections.Generic;

namespace SaveRoutes.Core
{
    public interface IManager
    {
        void AddUserToCTor(string fileName, Action<int, string, string, bool> AddNewUser);

        void AddRouteToCTor(string fileName, Action<int, string, string, string, string, bool> AddNewRoute);

        void AddUser(string fileName, User user);

        void AddRoute(string fileName, Route route);

        void RemoveItem(string fileName, List<string> list);
    }
}
