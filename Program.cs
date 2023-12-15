using HostingSystem.Models;

var (DaysToDescount, PercentToDescount, DailyRatePerPerson, DailyRatePerSuite, AgeLimitToFree, MaxSuites, MaxPeoplePerSuite) = 
    DefaultValuesConfig.ReadDailyRateConfiguration("Files/DefaultValues.json");

string principalGuestName;
int principalGuestAge, suitesToReservation;
DateTime checkInDate, checkOutDate;

Console.WriteLine("Olá! Seja bem vindo(a) ao Portal de Reservas do Thayane Hotel!");

Console.WriteLine("Por favor, insira o seu nome completo");
principalGuestName = ReadInput.ReadNonEmptyInput("O nome não pode estar vazio. Por favor, tente novamente.");

Console.WriteLine($"{principalGuestName} qual a sua idade?");
principalGuestAge = ReadInput.
    ReadPositiveIntInput("A idade não pode ser negativa. Por favor, tente novamente.");

Person principalGuest = new(principalGuestName, principalGuestAge);

Console.WriteLine("Vamos agora prosseguir com a sua reserva");

Console.WriteLine("Insira a data de entrada (formato: dd/MM/yyyy): ");
checkInDate = ReadInput.
    ReadDateInput("Formato de data inválido. Tente novamente seguindo o formato dd/MM/yyyy.");

Console.WriteLine("Agora insira a data de saída (formato: dd/MM/yyyy): ");
checkOutDate = ReadInput.
    ReadDateInput("Formato de data inválido. Tente novamente seguindo o formato dd/MM/yyyy.", 
        checkInDate.AddDays(1));

Console.WriteLine("Quantos quartos você deseja reservar?");
Console.WriteLine($"Temos até {MaxSuites} quartos disponíveis, todos com capacidade para até 3 pessoas");
Console.WriteLine($"O valor por quarto é de R${DailyRatePerSuite}, dando direito a 1 pessoa");
Console.WriteLine($"O valor por pessoa é de R${DailyRatePerSuite}");
Console.WriteLine($"Lembrando que crianças até {AgeLimitToFree} anos não pagam");
Console.WriteLine("E que ficando mais de 10 dias haverá um desconto de 10%");
suitesToReservation = ReadInput.
    ReadPositiveIntInput("A quantidade de quartos não pode ser negativa. Por favor, tente novamente.", 
        MaxSuites);

List<Suite> suites = [];
for (int i = 0; i < suitesToReservation; i++)
{
    Suite suite = new(i, MaxPeoplePerSuite, AgeLimitToFree);
    List<Person> guests = [];

    Console.WriteLine("Quantas pessoas estarão nesse quarto?");
    int peopleOnSuite = ReadInput.
        ReadPositiveIntInput("A quantidade de pessoas não pode ser negativa. Por favor, tente novamente.", 
            MaxPeoplePerSuite);

    for (int j = 0; j < peopleOnSuite && j < MaxPeoplePerSuite; j++)
    {
        Console.WriteLine("Qual o nome dessa pessoa?");
        string guestName = ReadInput.
            ReadNonEmptyInput("O nome não pode estar vazio. Por favor, tente novamente.");

        Console.WriteLine($"E qual a idade de {guestName}?");
        int guestAge = ReadInput.
            ReadPositiveIntInput("A idade não pode ser negativa. Por favor, tente novamente.");

        Person guest = new(guestName, guestAge);
        guests.Add(guest);
    }
    suite.AddGuests(guests);

    suites.Add(suite);
}

Reservation reservation = 
    new(DaysToDescount, PercentToDescount, DailyRatePerPerson, DailyRatePerSuite, principalGuest, suites, checkInDate, checkOutDate);

Console.WriteLine($"O valor total da reserva é: {reservation.CalculateValue()}");
Console.WriteLine("Reserva confirmada com sucesso!");
