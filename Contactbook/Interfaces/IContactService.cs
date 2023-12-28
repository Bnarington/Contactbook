using Contactbook.Models;
using Contactbook.Models.Responses;

namespace Contactbook.Interfaces
{
    public interface IContactService
    {
        IServiceResult AddContactToList(Contacts contact);
        IEnumerable<Contacts> GetContactFromList(string email);
        IEnumerable<Contacts> GetContactsFromFile();
        IServiceResult DeleteContactFromList(string email);
    }
}