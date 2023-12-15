namespace HostingSystem.Models;
public class Reservation(
    int daysToDescount, int percentToDescount,
    decimal dailyRatePerPerson, decimal dailyRatePerSuite, 
    Person principalGuest, List<Suite> suites, DateTime checkIn, DateTime checkOut)
{
    public int DaysToDescount { get; private set; } = daysToDescount;
    public int PercentToDescount { get; private set; } = percentToDescount;
    public decimal DailyRatePerPerson { get; private set; } = dailyRatePerPerson;
    public decimal DailyRatePerSuite { get; private set; } = dailyRatePerSuite;
    public Person PrincipalGuest { get; set; } = principalGuest;
    public List<Suite> Suites { get; set; } = suites;
    public DateTime CheckInDate { get; set; } = checkIn;
    public DateTime CheckOutDate { get; set; } = checkOut;

    public decimal CalculateValue(){
        int totalDays = (int)(CheckOutDate - CheckInDate).TotalDays;
        Console.WriteLine("Total de dias: " + totalDays);
        int payingGuests = 0;

        foreach(var suite in Suites){
            payingGuests += suite.PayingGuests() - 1;
        }

        decimal suitesValue = Suites.Count * DailyRatePerSuite;
        decimal guestsValue = payingGuests * DailyRatePerPerson;

        decimal totalValue = (suitesValue + guestsValue) * totalDays;
        if(totalDays > DaysToDescount) totalValue -= totalValue * PercentToDescount / 100;

        return totalValue;
    }
}