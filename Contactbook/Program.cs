using Contactbook.Interfaces;
using Contactbook.Models;


var contacts = new List<IContacts> 
{ 
    
     new Contacts { ContactId = Guid.NewGuid(), Address = "Andersvägen 11", Email = "anders@domain.se", FirstName = "Anders", LastName = "Andersson", PhoneNumber = 01234 }


};

foreach (var contact in contacts)
{
    switch(contact)
    {
        case Contacts contactz:
            Console.WriteLine($"Kontakt: {contactz.FirstName} {contactz.LastName}");
            break;



    }

}

