using Contactbook.Interfaces;

namespace Contactbook.Models;

public class Contacts : IContacts
{
    public Guid ContactId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; } 
    public string Address { get; set; } = null!;
}
