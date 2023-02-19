namespace ServerApp.Services
{
    public class Copilot
    {

        int CalculateDaysBetweenDates( DateTime startDate, DateTime endDate )
        {
            return (int)(endDate - startDate).TotalDays;
        }
    }
}
