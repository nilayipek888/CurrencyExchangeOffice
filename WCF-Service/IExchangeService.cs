using CoreWCF;

namespace WCF_Service;

[ServiceContract]
public interface IExchangeService
{
    [OperationContract]
    string GetServiceStatus();

    [OperationContract]
    Task<decimal> GetExchangeRateAsync(string currencyCode);
}
