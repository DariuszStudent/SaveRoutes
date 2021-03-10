namespace SaveRoutes.Core.Enums
{
    public static class EnumExtensions
    {
        public static string ToPolishString(this MonthsOfTheYear monthsOfTheYear)
        {
            switch (monthsOfTheYear)
            {
                case MonthsOfTheYear.January:
                    return "Styczeń";
                case MonthsOfTheYear.February:
                    return "Luty";
                case MonthsOfTheYear.March:
                    return "Marzec";
                case MonthsOfTheYear.April:
                    return "Kwiecień";
                case MonthsOfTheYear.May:
                    return "Maj";
                case MonthsOfTheYear.June:
                    return "Czerwiec";
                case MonthsOfTheYear.July:
                    return "Lipiec";
                case MonthsOfTheYear.August:
                    return "Sierpień";
                case MonthsOfTheYear.September:
                    return "Wrzesień";
                case MonthsOfTheYear.October:
                    return "Październik";
                case MonthsOfTheYear.November:
                    return "Listopad";
                case MonthsOfTheYear.December:
                    return "Grudzień";
                default:
                    return "NotSet";
            }
        }
    }
}
