
using Contactbook.Interfaces;
using Contactbook.Models;

namespace Contactbook.Services;


public class MenuServices : IMenuServices
//This class provides all Navigation in the program.
{
    private readonly IContactService _contactService = new ContactService();
    public void ShowMainMenu()
    {
        //this print the initial Main Menu when the program starts.
        Console.WriteLine("Welcome to your phonebook.");
        MenuTitle("MAIN MENU");
        Console.WriteLine();
        Console.WriteLine($"{"1. ",-3} Add a contact");
        Console.WriteLine($"{"2. ",-3} List contacts");
        Console.WriteLine($"{"3. ",-3} View detalied information about a contact");
        Console.WriteLine($"{"4. ",-3} Remove a contact");
        Console.WriteLine($"{"5. ",-3} Exit the application");
        Console.WriteLine();

        string command = "";
        while (command != "0")
        {
            //This prints the menu again when a function has been used.
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
                default:
                    Console.WriteLine("\nInvalid option, press any key to try again.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public void ShowAddMenu() //This menu option is used to add a contact.
    {
        Contacts contact = new Contacts();

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
                Console.WriteLine("The contact was added successfully.");
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

    public void ShowContactDetailMenu() //This is used to show detailed contact information, it picks the contact up using the email of the contact.
    {

        Console.Write("Which contact do you wish to view?\nSearch by typing the email adress: ");
        var email = Console.ReadLine()!;

        var res = _contactService.GetContactFromList(email); //Gathers the response from the Contactlist. 

        MenuTitle("Contact");
        Console.WriteLine();


        foreach (var isCorrectName in res) //Prints the contact in an appeasing manner. 
        {
            Console.WriteLine($"Fullname: {isCorrectName.FirstName} {isCorrectName.LastName}\nEmail: {isCorrectName.Email}\nAdress: {isCorrectName.Address}\nPhonenumber: {isCorrectName.PhoneNumber}");
        }
        PressToContinue();
    }

    public void ShowContactListMenu() //Shows the name of everyone in the contact list.
    {

        MenuTitle("Contact list");
        Console.WriteLine();

        var res = _contactService.GetContactsFromFile();
        foreach (var contact in res)
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
        }
        PressToContinue();
    }


    public void ShowRemoveContact() //lets you remove a contact from the contact list by typing out the email, todo: Add a better way to let the user choose who is to be removed.
    {

        MenuTitle("Remove a contact.");
        Console.WriteLine();

        Console.Write("Enter the email of the person you wish to remove: ");
        var email = Console.ReadLine()!;

        _contactService.DeleteContactFromList(email);

        var result = _contactService.DeleteContactFromList(email);

        switch (result.serviceStatus)
        {
            case Enums.ServiceStatus.SUCESS:
                Console.WriteLine();
                Console.WriteLine("The contact was successfully removed.");
                PressToContinue();
                break;

            case Enums.ServiceStatus.FAILED:
                Console.WriteLine();
                Console.WriteLine("Removing the contact failed.");
                Console.WriteLine("See error : " + result.Result.ToString());
                PressToContinue();
                break;
        }

    }


    //These functions control diffrent elements that are occuring in all the diffrent menu options.

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

    private void MenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"########### {title} ###########");
        Console.WriteLine();
    }

    private void PressToContinue()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue;");
        Console.ReadKey();
    }
}
