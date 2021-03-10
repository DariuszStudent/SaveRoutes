using SaveRoutes.Core.Enums;
using System;
using System.IO;

namespace SaveRoutes.Core
{
    public class MonthManager
    {
        Months months = new Months();

        private string Filename { get; set; } = "month.txt";

        public MonthManager()
        {
            if (!File.Exists(Filename))
            {
                return;
            }

            var fileName = File.ReadAllText(Filename);
            if (int.TryParse(fileName, out var result))
            {
                months.Month = result;
            }         
        }

        public void ShowMonths()
        {
            MonthsOfTheYear monthOfTheYear = MonthsOfTheYear.January;

            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine($"{i + 1}. {monthOfTheYear.ToPolishString()}");
                monthOfTheYear += 1;
            }
        }

        public MonthsOfTheYear ActuallyMonth()
        {
            MonthsOfTheYear monthsOfTheYear = MonthsOfTheYear.NotSet + months.Month;

            return monthsOfTheYear;
        }

        public string ActuallyMonthToPolish()
        {
            return ActuallyMonth().ToPolishString();
        }

        public void UserMonth(int userInput)
        {
            months.Month = userInput;
            File.Delete(Filename);
            File.WriteAllText(Filename, months.Month.ToString());
        }
    }
}
