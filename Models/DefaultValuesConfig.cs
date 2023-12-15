using Newtonsoft.Json;

namespace HostingSystem.Models;
public class DefaultValuesConfig(
    decimal dailyRatePerPerson, decimal dailyRatePerSuite, 
    int ageLimitToFree, int maxSuites, int maxPeoplePerSuite)
{
    public decimal DailyRatePerPerson { get; private set; } = dailyRatePerPerson;
    public decimal DailyRatePerSuite { get; private set; } = dailyRatePerSuite;
    public int AgeLimitToFree { get; private set; } = ageLimitToFree;
    public int MaxSuites { get; private set; } = maxSuites;
    public int MaxPeoplePerSuite { get; private set; } = maxPeoplePerSuite;

    public static (
        decimal DailyRatePerPerson, decimal DailyRatePerSuite, 
        int AgeLimitToFree, int MaxSuites, int MaxPeoplePerSuite) 
        ReadDailyRateConfiguration(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);

            DefaultValuesConfig config = JsonConvert.DeserializeObject<DefaultValuesConfig>(json);

            return (config.DailyRatePerPerson, config.DailyRatePerSuite, config.AgeLimitToFree, 
                config.MaxSuites, config.MaxPeoplePerSuite);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na leitura do arquivo de configuração: {ex.Message}");
            throw;
        }
    }
}