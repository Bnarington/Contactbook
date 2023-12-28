using Contactbook.Enums;
using Contactbook.Interfaces;
using Contactbook.Models.Responses;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Contactbook.Services;


public class ContactService : IContactService
{
    private List<IContacts> _contacts = [];

    private readonly FileService _fileService = new FileService(@"D:\Skoldokument\Cprojects\Contacts.json");

    private readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All
    };

    public IServiceResult AddContactToList(IContacts contact)
    {
        IServiceResult response = new ServiceResult();

        try
        {
            var res = _fileService.GetFromFile();

            _contacts = JsonConvert.DeserializeObject<List<IContacts>>(res, JsonSerializerSettings)!;
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                _fileService.SaveTofile(JsonConvert.SerializeObject(_contacts, JsonSerializerSettings));
                response.serviceStatus = ServiceStatus.SUCESS;               
            }
            else
            {
                response.serviceStatus = ServiceStatus.CONTACT_EXISTS;
            }            
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.serviceStatus = ServiceStatus.FAILED;
            response.Result = ex.Message;
        }
        
        return response;
    }

    public IEnumerable<IContacts> GetContactFromList(string email)//,  Func<Contacts, bool> predicate)
    {
        IServiceResult response = new ServiceResult();

        try
        {
            var contact = _fileService.GetFromFile();
            if (!string.IsNullOrEmpty(contact))
            {
                response.serviceStatus = ServiceStatus.SUCESS;

                _contacts = JsonConvert.DeserializeObject<List<IContacts>>(contact, JsonSerializerSettings)!;

                _contacts = _contacts.Where(x  => x.Email == email).ToList();
            }


        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.serviceStatus = ServiceStatus.FAILED;
            response.Result = ex.Message;
        }

        return _contacts;
    }

    public IEnumerable<IContacts> GetContactsFromFile()
    {
        IServiceResult response = new ServiceResult();

        try
        {
            var contact = _fileService.GetFromFile();
            if (!string.IsNullOrEmpty(contact))
            {
                response.serviceStatus = ServiceStatus.SUCESS;
                _contacts = JsonConvert.DeserializeObject<List<IContacts>>(contact)!;
            }

        }

        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
            response.serviceStatus = ServiceStatus.FAILED;
            response.Result = ex.Message;
        }

        return _contacts;
    }

    public IServiceResult DeleteContactList(IContacts contact)
    {
        throw new NotImplementedException();
    }
}



//Scrap pile.

//public IServiceResult GetContactsFromList()
//{
//    IServiceResult response = new ServiceResult();

//    try
//    {
//        response.serviceStatus = Enums.ServiceStatus.SUCESS;
//        response.Result = _contacts;
//    }
//    catch (Exception ex)
//    {
//        Debug.WriteLine(ex.Message);
//        response.serviceStatus = Enums.ServiceStatus.FAILED;
//        response.Result = ex.Message;
//    }

//    return response;
//}