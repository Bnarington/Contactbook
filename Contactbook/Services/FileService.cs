//This file adds a fileservice. The program loads or saves to a json file. 

using Contactbook.Interfaces;
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

    public bool SaveTofile(string content) //this saves to the json file. 
    {
        try
        {
            using (var sw = new StreamWriter(_filePath, true)) 
            {
                sw.WriteLine(content);
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
