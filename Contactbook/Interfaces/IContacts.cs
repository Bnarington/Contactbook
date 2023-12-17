namespace Contactbook.Interfaces;

public interface IContacts
{
    Guid ContactId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    int PhoneNumber { get; set; }
    string Address { get; set; }
}