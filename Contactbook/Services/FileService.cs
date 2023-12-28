//This file adds a fileservice. The program loads or saves to a json file. 

using Contactbook.Interfaces;
using Contactbook.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Contactbook.Services;

public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath;

    public string GetFromFile() //This grabs the contacts list from the json file.
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }            
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return null!;
    }

    public bool SaveToFile(Contacts content) //this saves to the json file. 
    {
        try
        {
            List<Contacts> contactList;

            if (File.Exists(_filePath))
            {
                var jsonFile = File.ReadAllText(_filePath);
                contactList = JsonConvert.DeserializeObject<List<Contacts>>(jsonFile) ?? [];
            }

            else
            {
                contactList = new List<Contacts>();
            }


            contactList.Add (content);

            var json = JsonConvert.SerializeObject(contactList);

            using (var sw = new StreamWriter(_filePath)) 
            {
                sw.WriteLine(json);
            }
            return true;
        }

        catch (Exception ex)
        { 
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool DeleteFromFile(string email) //At the moment you can only delete a user by knowing their email adress, I wish to expand on this to use another method that is more convenient to the user.
    {
        try
        {
            List<Contacts> contactList;

            using (var sw = new StreamReader(_filePath))
            {
                var jsonFile = sw.ReadToEnd();
                contactList = JsonConvert.DeserializeObject<List<Contacts>>(jsonFile) ?? new List<Contacts>();
            }


            foreach (var contact in contactList)
            {
                var contactToRemove = contactList.FirstOrDefault(c => c.Email == email);
                if (contactToRemove != null) {  contactToRemove.Delete(); }
            }

            using (var sw = new StreamWriter(_filePath))
            {
                var jsonFile = JsonConvert.SerializeObject(contactList.Where(c => !c.IsDeleted)); //This rebuilds the json file, not including the contact who has been earmarked for deletion.
                sw.WriteLine(jsonFile);
            }
            return true;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}
