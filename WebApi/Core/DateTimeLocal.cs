namespace Core
{
    public static class DateTimeLocal
    {
        public static DateTime GetDateTime()
        {
            return DateTime.UtcNow.AddHours(3);
        }

        //TODO
        public static DateTime GetDate()
        {
            return DateTime.UtcNow.AddHours(3).Date;
        }

       
    }
}