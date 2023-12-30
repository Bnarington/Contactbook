using Contactbook.Models;
using Contactbook.Services;

namespace ContactBook.test;

public class FileService_tests
{
    [Fact]

    public void GetFromFile_ShouldReadFromFileLocatedAtFilePath_ThenReturnList()
    {
        //Arrange
        FileService fileService = new FileService(@"D:\Skoldokument\Cprojects\Contacts.json");

        //Act
        fileService.GetFromFile();

        //Assert
        Assert.NotNull(fileService);
    }

    [Fact]

    public void SaveToFile_ShouldSaveIncomingContactsToTheJsonFile_ThenReturnTrue()
    {
        //Arrange
        FileService fileService = new FileService(@"D:\Skoldokument\Cprojects\test.json");
        Contacts contact = new Contacts { Address = "Håltavägen", ContactId = Guid.NewGuid(), Email = "test@domain.se", FirstName = "Test", IsDeleted = false, LastName = "Testerson", PhoneNumber = 123456 };

        //Act
        bool result = fileService.SaveToFile(contact);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void SaveToFile_ShouldFailToSaveIfTheFilePathDoesNotExist_ThenReturnFalse()
    {
        //Arrange
        FileService fileService = new FileService($@"{Guid.NewGuid()}\test.json");
        Contacts contact = new Contacts { Address = "Håltavägen", ContactId = Guid.NewGuid(), Email = "test@domain.se", FirstName = "Test", IsDeleted = false, LastName = "Testerson", PhoneNumber = 123456 };

        //Act
        bool result = fileService.SaveToFile(contact);

        //Assert
        Assert.False(result);
    }

    [Fact]

    public void DeleteFromFile_ShouldRemoveAContactFromTheJsonListWithCorrectEmail_ThenReturnTrue()
    {
        //Arrange
        FileService fileService = new FileService(@"D:\Skoldokument\Cprojects\test.json");

        //Act
        bool result = fileService.DeleteFromFile("test@domain.se");


        //Assert


        Assert.True(result);
    }

    [Fact]
    
    public void DeleteFromFile_ShouldNotRemoveAContactFromTheJsonListWithUnknownEmail_ThenReturnFalse()
    {
        //Arrange
        FileService fileService = new FileService(@"D:\Skoldokument\Cprojects\test.json");

        //Act
        bool result = fileService.DeleteFromFile($@"{Guid.NewGuid()}domain.se");


        //Assert
        Assert.False(result);
    }
}



