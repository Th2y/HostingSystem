using HostingSystem.Models;

DailyRate dailyRate = new(50.0m, 100.0m, 5);

Console.WriteLine("Olá! Seja bem vindo(a) ao Portal de Reservas do Thayane Hotel!");

Console.WriteLine("Por favor, insira o seu nome completo");
string principalGuestName = Console.ReadLine();

Console.WriteLine($"{principalGuestName} qual a sua idade?");
int principalGuestAge = int.Parse(Console.ReadLine());

Person principalGuest = new(principalGuestName, principalGuestAge);

Console.WriteLine("Vamos agora prosseguir com a sua reserva");

Console.WriteLine("Insira a data de entrada (formato: dd-MM-yyyy): ");
string checkInInput = Console.ReadLine();
DateTime.TryParseExact(checkInInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime checkInDate);

Console.WriteLine("Agora insira a data de saída (formato: dd-MM-yyyy): ");
string checkOutInput = Console.ReadLine();
DateTime.TryParseExact(checkOutInput, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime checkOutDate);

Console.WriteLine("Quantos quartos você deseja reservar?");
Console.WriteLine("Temos até 10 quartos disponíveis, todos com capacidade para até 3 pessoas");
Console.WriteLine($"O valor por quarto é de R${dailyRate.DailyRatePerSuite}, dando direito a 1 pessoa");
Console.WriteLine($"O valor por pessoa é de R${dailyRate.DailyRatePerSuite}");
Console.WriteLine($"Lembrando que crianças até {dailyRate.AgeLimitToFree} anos não pagam");
Console.WriteLine("E que ficando mais de 10 dias haverá um desconto de 10%");
int suitesToReservation = int.Parse(Console.ReadLine());

List<Suite> suites = [];
for(int i = 0; i < suitesToReservation; i++){
    Suite suite = new(i, 3, dailyRate.AgeLimitToFree);
    List<Person> guests = [];

    Console.WriteLine("Quantas pessoas estarão nesse quarto?");
    int peopleOnSuite = int.Parse(Console.ReadLine());

    for(int j = 0; j < peopleOnSuite && j < 3; j++){
        Console.WriteLine("Qual o nome dessa pessoa?");
        string guestName = Console.ReadLine();

        Console.WriteLine($"E qual a idade de {guestName}?");
        int guestAge = int.Parse(Console.ReadLine());

        Person guest = new(guestName, guestAge);
        guests.Add(guest);
    }
    suite.AddGuests(guests);

    suites.Add(suite);
}

Reservation reservation = new(dailyRate.DailyRatePerPerson, dailyRate.DailyRatePerSuite, principalGuest, suites, checkInDate, checkOutDate);

Console.WriteLine($"O valor total da reserva é: {reservation.CalculateValue()}");
Console.WriteLine("Agradecemos a sua reserva, até logo!");
