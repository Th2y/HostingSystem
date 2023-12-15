namespace HostingSystem.Models;
public class Reservation(
    decimal dailyRatePerPerson, decimal dailyRatePerSuite, 
    Person principalGuest, List<Suite> suites, DateTime checkIn, DateTime checkOut)
{
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
        if(totalDays > 10) totalValue -= totalValue * 0.1m;

        return totalValue;
    }
}