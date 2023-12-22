using Contactbook.Enums;
using Contactbook.Interfaces;

namespace Contactbook.Models.Responses;


public class ServiceResult : IServiceResult
{
    public ServiceStatus serviceStatus { get; set; }

    public object Result { get; set; } = null!;
}
