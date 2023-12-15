namespace HostingSystem.Models;
public class Suite(int number, int guestsLimit, int ageLimitToFree)
{
    public int Number { get; private set; } = number;
    public int GuestsLimit { get; private set; } = guestsLimit;
    public int AgeLimitToFree { get; private set; } = ageLimitToFree;
    public List<Person> Guests { get; private set; }

    public void AddGuests(List<Person> guests){
        Guests = guests;
    }

    public int PayingGuests(){
        int payingGuests = 0;

        foreach(var guest in Guests){
            if(guest.Age > AgeLimitToFree) payingGuests++;
        }

        return payingGuests;
    }
}