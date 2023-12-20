using Contactbook.Interfaces;
using Newtonsoft.Json;

namespace Contactbook.Models;

public class CreateContact
{
    public static List<IContacts> Contact = new List<IContacts>();


    public static void ContactList()
    {

        Contacts contact = new Contacts();

        contact.ContactId = Guid.NewGuid();
        Console.Write("Enter firstname: " );
        contact.FirstName = Console.ReadLine();
        Console.Write("Enter lastname: ");
        contact.LastName = Console.ReadLine();
        Console.Write("Enter email: ");
        contact.Email = Console.ReadLine();
        Console.Write("Enter Adress: ");
        contact.Address = Console.ReadLine();
        Console.Write("Enter phonenumber: ");
        contact.PhoneNumber = Convert.ToInt32(Console.ReadLine());

        Contact.Add(contact);
    }
}