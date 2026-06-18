using System.ServiceModel;

namespace Client_Application;

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

public class ExchangeResult
{
    public string CurrencyCode { get; set; } = string.Empty;
    public decimal ExchangeRate { get; set; }
    public decimal InputAmount { get; set; }
    public decimal OutputAmount { get; set; }
    public string OperationType { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}

public static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Currency Exchange Office Client");
        Console.WriteLine("Make sure the WCF-Service project is running first.\n");

        var binding = new BasicHttpBinding();
        var endpoint = new EndpointAddress("http://localhost:5000/ExchangeService");
        var factory = new ChannelFactory<IExchangeService>(binding, endpoint);
        IExchangeService client = factory.CreateChannel();

        try
        {
            Console.WriteLine(client.GetServiceStatus());
            Console.WriteLine();

            Console.Write("Currency code, for example USD, EUR, GBP: ");
            string code = Console.ReadLine() ?? "USD";
            if (string.IsNullOrWhiteSpace(code)) code = "USD";

            decimal rate = await client.GetExchangeRateAsync(code);
            Console.WriteLine($"Current {code.ToUpper()} exchange rate from NBP API: {rate} PLN");

            ExchangeResult buyResult = await client.BuyCurrencyAsync(code, 1000m);
            Console.WriteLine(buyResult.Message);

            ExchangeResult sellResult = await client.SellCurrencyAsync(code, 100m);
            Console.WriteLine(sellResult.Message);

            ((IClientChannel)client).Close();
            factory.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            ((IClientChannel)client).Abort();
            factory.Abort();
        }
    }
}
