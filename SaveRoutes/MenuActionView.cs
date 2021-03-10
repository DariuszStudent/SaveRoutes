using SaveRoutes.Core;
using SaveRoutes.Core.Enums;
using System;

namespace SaveRoutes
{
    public class MenuActionView
    {
        public void ShowMenu()
        {      
            Console.WriteLine("1. Wybierz miesiąc");
            Console.WriteLine("2. Dodaj kierowcę");
            Console.WriteLine("3. Usuń kierowcę");
            Console.WriteLine("4. Dodaj trasę");
            Console.WriteLine("5. Usuń trasę");
            Console.WriteLine("6. Pokaż wszystkie trasy");
            Console.WriteLine("9. Wyjście\n");
        }
    }
}
