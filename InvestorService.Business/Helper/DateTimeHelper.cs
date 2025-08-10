namespace InvestorService.Business.Helper
{
    public static class DateTimeHelper
    {
        public static string FormatDateWithOrdinal(DateTime date)
        {
            int day = date.Day;
            string suffix = GetOrdinalSuffix(day);
            return $"{date:MMMM} {day}{suffix}, {date:yyyy}";
        }

        private static string GetOrdinalSuffix(int day)
        {
            if (day >= 11 && day <= 13)
                return "th";

            return (day % 10) switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th"
            };
        }
    }
}
