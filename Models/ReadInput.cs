namespace HostingSystem.Models;

public static class ReadInput
{
    public static string ReadNonEmptyInput(string errorPrompt)
    {
        string input;
        do
        {
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(errorPrompt);
            }

        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }

    public static int ReadPositiveIntInput(string errorPrompt, int? max = 0)
    {
        int value;
        do
        {
            string input = ReadNonEmptyInput(errorPrompt);

            if (int.TryParse(input, out value))
            {
                if (value < 0)
                {
                    Console.WriteLine(errorPrompt);
                }
                else if(max > 0 && value > max)
                {
                    Console.WriteLine("Insira um valor até " + max);
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine(errorPrompt);
            }

        } while (true);

        return value;
    }

    public static DateTime ReadDateInput(string errorPrompt, DateTime? minDate = null)
    {
        DateTime date;
        do
        {
            string input = ReadNonEmptyInput(errorPrompt);

            if (DateTime.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                if (!minDate.HasValue || date >= minDate.Value)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"A data deve ser posterior a {minDate:dd/MM/yyyy}. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine(errorPrompt);
            }

        } while (true);

        return date;
    }
}