
using Contactbook.Interfaces;
using Contactbook.Models;

namespace Contactbook.Services;


public interface IMenuService
{
    void ShowMainMenu();
}
public class MenuServices : IMenuService //This class provides all Navigation in the program.
{
    private readonly IContactService _contactService = new ContactService();
    public void ShowMainMenu()
    {
        Console.WriteLine("Welcome to your phonebook.");
        MenuTitle("MAIN MENU");
        Console.WriteLine();
        Console.WriteLine($"{"1. ", -3} Add a contact");
        Console.WriteLine($"{"2. ",-3} List contacts");
        Console.WriteLine($"{"3. ",-3} View detalied information about a contact");
        Console.WriteLine($"{"4. ",-3} Remove a contact");
        Console.WriteLine($"{"5. ",-3} Exit the application");
        Console.WriteLine();

        string command = "";
        while (command != "0")
        {
            MenuTitle("MAIN MENU");
            Console.WriteLine();
            Console.WriteLine($"{"1. ",-3} Add a contact");
            Console.WriteLine($"{"2. ",-3} List contacts");
            Console.WriteLine($"{"3. ",-3} View detalied information about a contact");
            Console.WriteLine($"{"4. ",-3} Remove a contact");
            Console.WriteLine($"{"5. ",-3} Exit the application");
            Console.WriteLine();
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
                    ShowContactDetailMenu();
                    break;
                case "4":
                    ShowRemoveContact();
                    break;
                case "5":
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
                Console.WriteLine();
                Console.WriteLine("The customer was added successfully.");
                PressToContinue();
                break;

            case Enums.ServiceStatus.CONTACT_EXISTS:
                Console.WriteLine();
                Console.WriteLine("Contact allready exist.");
                PressToContinue();
                break;

            case Enums.ServiceStatus.FAILED:
                Console.WriteLine();
                Console.WriteLine("Adding the contact failed.");
                Console.WriteLine("See error : " + result.Result.ToString());
                PressToContinue();
                break;
        }
    }

    public void ShowContactDetailMenu()
    {

        Console.Write("Which contact do you wish to view?\nSearch by typing the email adress: ");
        var email = Console.ReadLine()!;

        var res = _contactService.GetContactFromList(email);

        MenuTitle("Contact");
        Console.WriteLine();

        
        foreach (var isCorrectName in res)
        {
            Console.WriteLine($"Fullname: {isCorrectName.FirstName} {isCorrectName.LastName}\nEmail: {isCorrectName.Email}\nAdress: {isCorrectName.Address}\nPhonenumber: {isCorrectName.PhoneNumber}");
        }
        PressToContinue();
    }

    public void ShowContactListMenu()
    {

        MenuTitle("Contact list");
        Console.WriteLine();

        var res = _contactService.GetContactsFromFile();
        foreach (var contact in res)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}" );
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
