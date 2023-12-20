using Contactbook.Interfaces;
using Contactbook.Models;
using Newtonsoft.Json;


Console.WriteLine("Welcome to your phonebook.");
Console.ReadKey();

string command = "";
while (command != "exit")
{
    Console.Clear();
    Console.WriteLine("Please enter a command: ");
    command = Console.ReadLine().ToLower();
    switch (command)
    {
        case "add":
            CreateContact.ContactList();
            break;
        //case "remove":
        //    RemovePerson();
        //    break;
        //case "list":
        //    ListPeople();
        //    break;
    }
}

//var contacts = new List<IContacts>
//{

//     new Contacts 
//     { 
//         ContactId = Guid.NewGuid(), 
//         Address = "Andersvägen 11", 
//         Email = "anders@domain.se", 
//         FirstName = "Anders", 
//         LastName = "Andersson", 
//         PhoneNumber = 01234 
//     }


//};


//string json = JsonConvert.SerializeObject(ContactsList, new JsonSerializerSettings
//{
//    Formatting = Formatting.Indented,
//    TypeNameHandling = TypeNameHandling.Auto
//});


//Console.Write(json);
//Console.ReadKey();

//var list = JsonConvert.DeserializeObject<List<IContacts>>(json, new JsonSerializerSettings //gör en lista från Json format. 
//{
//    TypeNameHandling = TypeNameHandling.Auto
//});

//if (list != null) //Om listan inte är tom gå igenom listan.
//{
//    foreach (var contact in list)
//    {
//        switch (contact)
//        {
//            case Contacts contactz:
//                Console.WriteLine($"Kontakt: {contactz.FirstName} {contactz.LastName}");
//                break;



//        }

//    }
//}



