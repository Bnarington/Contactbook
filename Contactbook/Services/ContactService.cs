using Contactbook.Enums;
using Contactbook.Interfaces;
using Contactbook.Models;
using Contactbook.Models.Responses;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Contactbook.Services;


public class ContactService : IContactService
{
    private static readonly List<IContacts> _contacts = [];

    public IServiceResult AddContactToList(IContacts contact)
    {
        IServiceResult response = new ServiceResult();

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                response.serviceStatus = Enums.ServiceStatus.SUCESS;               
            }
            else
            {
                response.serviceStatus = Enums.ServiceStatus.CONTACT_EXISTS;
            }            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.serviceStatus = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }
        
        return response;
    }

    public IServiceResult DeleteContactFromList(Func<Contacts, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IServiceResult GetContactFromList(Func<Contacts, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public IServiceResult GetContactsFromList()
    {
        IServiceResult response = new ServiceResult();

        try
        {
            response.serviceStatus = Enums.ServiceStatus.SUCESS;
            response.Result = _contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.serviceStatus = Enums.ServiceStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }

    public IServiceResult UpdateContactList(IContacts contact)
    {
        throw new NotImplementedException();
    }
}
