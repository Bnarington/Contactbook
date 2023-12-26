namespace Contactbook.Interfaces
{
    public interface IFileService
    {
        string GetFromFile();
        bool SaveTofile(string content);
    }
}