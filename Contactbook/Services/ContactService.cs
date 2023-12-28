using Contactbook.Enums;
using Contactbook.Interfaces;
using Contactbook.Models;
using Contactbook.Models.Responses;
using Newtonsoft.Json;
using System.Diagnostics;


namespace Contactbook.Services;


public class ContactService : IContactService
{
    private List<Contacts> _contacts = [];

    private readonly FileService _fileService = new FileService(@"D:\Skoldokument\Cprojects\Contacts.json"); //change this to whereever you wish to look for the json file.

    public IServiceResult AddContactToList(Contacts contact) //Adds a contact to the contact book and sends it to the json file.
    {
        IServiceResult response = new ServiceResult();

        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email)) //checks if the email exists allready in the contactbook.
            {
                _contacts.Add(contact);
                _fileService.SaveToFile(contact);
                _contacts.Clear();  //Clears the list in preparation for adding another contact. 
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

    public IEnumerable<Contacts> GetContactFromList(string email) //Gets a single contact from the contact json.
    {
        try
        {
            var contact = _fileService.GetFromFile();
            if (!string.IsNullOrEmpty(contact))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contacts>>(contact)!;
                _contacts = _contacts.Where(x  => x.Email == email).ToList(); //Looks for a contacts email and puts that user in a list.
            }


        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        return _contacts.ToList();
    }

    public IEnumerable<Contacts> GetContactsFromFile() //Gets all contacts from the contact json.
    {

        try
        {
            var contact = _fileService.GetFromFile();
            if (!string.IsNullOrEmpty(contact)) //checks if the contact json is empty before trying to deserialize it. 
            {
                _contacts = JsonConvert.DeserializeObject<List<Contacts>>(contact)!;
            }

        }

        catch (Exception ex) 
        {
            Debug.WriteLine(ex.Message);
        }

        return _contacts.ToList();
    }

    public IServiceResult DeleteContactFromList(string email) //Removes a contact from the contactbook.
    {
        IServiceResult response = new ServiceResult();

        try
        {
            response.serviceStatus = ServiceStatus.SUCESS;
            _fileService.DeleteFromFile(email);

        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            response.serviceStatus = ServiceStatus.FAILED;
            response.Result = ex.Message;
        }

        return response;
    }
}