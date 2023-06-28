using System;

class Program
{
    static void Main()
    {
        using (var context = new MyDbContext())
        {
            // Rufe die Daten aus der Datenbank ab und gib sie aus
            var people = context.People.ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Id}, Name: {person.Name}");
            }
        }
    }
}
