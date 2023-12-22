using Contactbook.Interfaces;
using Newtonsoft.Json;

namespace Contactbook.Models;

public class CreateContact
{
    public static List<IContacts> Contact = new List<IContacts>();


    public static void ContactList() 
    {
        string commands = "";
        while (commands != "stop")
        {
            Console.WriteLine("Please enter users, type 'stop' when you wish to exit the add user interface.");
            commands = Console.ReadLine().ToLower();


            IContacts contact = new Contacts();

            contact.ContactId = Guid.NewGuid();
            Console.Write("Enter firstname: ");
            contact.FirstName = Console.ReadLine()!;
            Console.Write("Enter lastname: ");
            contact.LastName = Console.ReadLine()!;
            Console.Write("Enter email: ");
            contact.Email = Console.ReadLine()!;
            Console.Write("Enter Adress: ");
            contact.Address = Console.ReadLine()!;
            Console.Write("Enter phonenumber (Optional): ");
            contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());

            Contact.Add(contact);


        }

        if (commands == "stop")
        {
            Console.WriteLine("Thank you, please come again.");
        }

    }

    public static void MakeJson()
    {
        string json = JsonConvert.SerializeObject(Contact, new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.Auto
        });
    }
}