using Contactbook.Enums;

namespace Contactbook.Interfaces
{
    public interface IServiceResult
    {
        object Result { get; set; }
        ServiceStatus serviceStatus { get; set; }
    }
}