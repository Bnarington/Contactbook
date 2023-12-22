namespace Contactbook.Interfaces;

public interface IContacts
{
    public Guid ContactId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int? PhoneNumber { get; set; }
    public string Address { get; set; }
}