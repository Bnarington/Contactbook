using Contactbook.Interfaces;

namespace Contactbook.Models;

public class Contacts : IContacts
{
    public bool IsDeleted { get; set; }
    public Guid ContactId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int? PhoneNumber { get; set; } 
    public string Address { get; set; } = null!;

    public void Delete() //to delete a contact the IsDeleted tag is added to and existing user.
    {
        IsDeleted = true;       
    }
}
