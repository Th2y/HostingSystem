namespace HostingSystem.Models;
public class DailyRate(decimal dailyRatePerPerson, decimal dailyRatePerSuite, int ageLimitToFree)
{
    public decimal DailyRatePerPerson { get; private set; } = dailyRatePerPerson;
    public decimal DailyRatePerSuite { get; private set; } = dailyRatePerSuite;

    public int AgeLimitToFree { get; private set; } = ageLimitToFree;
}