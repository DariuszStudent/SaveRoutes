using System;
using System.Collections.Generic;

namespace SaveRoutes.Core
{
    public interface IManager
    {
        void AddUserToCTor(Action<int, string, string, bool> AddNewUser);

        void AddRouteToCTor(Action<int, string, string, string, string, bool> AddNewRoute);

        void AddUser(User user);

        void AddRoute(Route route);

        void RemoveUser(List<string> list);

        void RemoveRoute(List<string> list);
    }
}
