
using Contactbook.Interfaces;
using Contactbook.Models;

namespace Contactbook.Services;


public interface IMenuService
{
    void ShowMainMenu();
}
public class MenuServices : IMenuService
{
    private readonly IContactService _contactService = new ContactService();
    public void ShowMainMenu()
    {
        Console.WriteLine("Welcome to your phonebook.");
        MenuTitle("MAIN MENU");
        Console.WriteLine();
        Console.WriteLine($"{"1. ", -3} Add a contact");
        Console.WriteLine($"{"2. ",-3} List contacts");
        Console.WriteLine($"{"3. ",-3} Remove a contact");
        Console.WriteLine($"{"0. ",-3} Exit the application");

        string command = "";
        while (command != "0")
        {
            Console.WriteLine("Choose a number from the list to continue.");
            command = Console.ReadLine().ToLower();
            switch (command)
            {
                case "1":
                    ShowAddMenu();
                    break;
                case "2":
                    ShowContactListMenu();
                    break;
                case "3":
                    ShowRemoveContact();
                    break;
                case "4":
                    ShowExit();
                    break;
                default : 
                    Console.WriteLine("\nInvalid option, press any key to try again.");
                    Console.ReadKey();
                    break;
        }
        }
    }
    public void ShowAddMenu()
    {
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


        var result = _contactService.AddContactToList(contact);

        switch (result.serviceStatus)
        {
            case Enums.ServiceStatus.SUCESS: 
                Console.WriteLine("The customer was added successfully.");
                break;

            case Enums.ServiceStatus.CONTACT_EXISTS: 
                Console.WriteLine("Contact allready exist.");
                break;

            case Enums.ServiceStatus.FAILED:
                Console.WriteLine("Adding the contact failed.");
                Console.WriteLine("See error : " + result.Result.ToString());
                break;
        }
    }

    public void ShowContactDetailMenu()
    {
        
    }

    public void ShowContactListMenu()
    {
        MenuTitle("Contact list");
        var res = _contactService.GetContactsFromList();

        if (res.serviceStatus == Enums.ServiceStatus.SUCESS) 
        { 
            if (res.Result is List<IContacts> contactList)
            {
                if (!contactList.Any())
                {
                    Console.WriteLine("Nothing in here!");
                }
                else
                {
                    foreach (var contact in contactList)
                    {
                        Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}>");
                    }
                }
            }
        }
        PressToContinue();
    }


    public void ShowRemoveContact()
    {
        
    }

    private void ShowExit()
    {
        Console.Write("Do you really wish to go? :( y/n: ");
        var selection = Console.ReadLine() ?? "";

        if (selection.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Good bye!");
            Environment.Exit(0);
        }
    }


    private void MenuTitle (string title)
    {
        Console.Clear();
        Console.WriteLine($"########### {title} ###########");
        Console.WriteLine();
    }

    private void PressToContinue ()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue;");
        Console.ReadKey();
    }
}
