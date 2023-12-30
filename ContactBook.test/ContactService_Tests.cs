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


        //Act


        //Assert
        
    
    }
}
