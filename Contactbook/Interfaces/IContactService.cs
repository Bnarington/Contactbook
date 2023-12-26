using Contactbook.Models;
using Contactbook.Models.Responses;

namespace Contactbook.Interfaces
{
    public interface IContactService
    {
        IServiceResult AddContactToList(IContacts contact);
        IEnumerable<IContacts> GetContactFromList(string email);//, Func<Contacts, bool> predicate);
        //IServiceResult GetContactsFromList();
        IEnumerable<IContacts> GetContactsFromFile();
        IServiceResult DeleteContactList(IContacts contact);
    }
}