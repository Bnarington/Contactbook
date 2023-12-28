using Contactbook.Models;

namespace Contactbook.Interfaces
{
    public interface IFileService
    {
        string GetFromFile();
        bool SaveToFile(Contacts content);
        bool DeleteFromFile(string email);
    }
}