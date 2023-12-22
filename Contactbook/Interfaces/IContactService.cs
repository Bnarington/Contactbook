using Contactbook.Models;
using Contactbook.Models.Responses;

namespace Contactbook.Interfaces
{
    public interface IContactService
    {
        IServiceResult AddContactToList(IContacts contact);
        IServiceResult GetContactFromList(Func<Contacts, bool> predicate);
        IServiceResult GetContactsFromList();
        IServiceResult UpdateContactList(IContacts contact);
        IServiceResult DeleteContactFromList(Func<Contacts, bool> predicate);
    }
}