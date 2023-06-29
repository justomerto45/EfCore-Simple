using EfCore_Easy;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new MyDbContext())
        {
            // Hinzufügen einer Person zur Datenbank
            var person = new Person { Name = "Jäger Meister" };
            context.People.Add(person);
            context.SaveChanges();

            Console.WriteLine("Datenbankeintrag erfolgreich erstellt.");

            // Abrufen aller Personen aus der Datenbank
            var people = context.People.ToList();
            foreach (var p in people)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}");
            }
        }
    }
}
