using CoreWCF;
using System.Runtime.Serialization;

namespace WCF_Service;

[ServiceContract]
public interface IExchangeService
{
    [OperationContract]
    string GetServiceStatus();

    [OperationContract]
    Task<decimal> GetExchangeRateAsync(string currencyCode);

    [OperationContract]
    Task<decimal> GetHistoricalExchangeRateAsync(string currencyCode, string date);

    [OperationContract]
    Task<ExchangeResult> BuyCurrencyAsync(string currencyCode, decimal plnAmount);

    [OperationContract]
    Task<ExchangeResult> SellCurrencyAsync(string currencyCode, decimal foreignCurrencyAmount);
}

[DataContract]
public class ExchangeResult
{
    [DataMember]
    public string CurrencyCode { get; set; } = string.Empty;

    [DataMember]
    public decimal ExchangeRate { get; set; }

    [DataMember]
    public decimal InputAmount { get; set; }

    [DataMember]
    public decimal OutputAmount { get; set; }

    [DataMember]
    public string OperationType { get; set; } = string.Empty;

    [DataMember]
    public string Message { get; set; } = string.Empty;
}
