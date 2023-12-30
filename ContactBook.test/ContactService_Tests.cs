using Contactbook.Interfaces;
using Contactbook.Models;
using Contactbook.Services;

namespace ContactBook.test;

public class ContactService_Tests
{
    [Fact]

    public void AddContactToList_ShouldAddOneContactToContactList_ThenReturnResponse()
    {
        //Arrange
        Contacts contact = new Contacts { Address = "Håltavägen", ContactId = Guid.NewGuid(), Email = "test@domain.se", FirstName = "Test", IsDeleted = false, LastName = "Testerson", PhoneNumber = 123456 };
        IContactService contactService = new ContactService();

        //Act
        IServiceResult result = contactService.AddContactToList(contact);

        //Assert
        Assert.NotNull(result);
    }

    [Fact]

    public void GetContactFromList_ShouldGatherContactsFromTheJsonFile_ThenReturnContactsinAList()
    {
        //Arrange
        IContactService contactService= new ContactService();


        //Act
        IEnumerable<Contacts> resultList = contactService.GetContactFromList("test@domain.se");
 
        //Assert
        Assert.NotNull(resultList);

    }

    [Fact]

    public void GetContactFromFile_ShouldGatherContactsFromTheJsonFile_ThenReturnContactsinAList()
    {
        //Arrange
        IContactService contactService= new ContactService();

        
        //Act
        IEnumerable<Contacts> resultList = contactService.GetContactsFromFile();

       
        //Assert
        Assert.NotNull(resultList);
    }

    [Fact]

    public void DeleteContactFromFile_ShouldDeleteAContactFromtheJsonFile_ThenReturnASuccess ()
    {
        //Arrange
        IContactService contactService= new ContactService();
        //Act
        IServiceResult result = contactService.DeleteContactFromList("test@domain.se");
        //Assert
        Assert.NotNull(result);
    }
}