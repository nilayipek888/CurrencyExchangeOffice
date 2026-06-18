using System.ServiceModel;

[ServiceContract]
public interface IExchangeService
{
    [OperationContract]
    string GetServiceStatus();

    [OperationContract]
    Task<decimal> GetExchangeRateAsync(string currencyCode);
}

Console.WriteLine("Currency Exchange Office Client");

var binding = new BasicHttpBinding();
var endpoint = new EndpointAddress("http://localhost:5000/ExchangeService");
var factory = new ChannelFactory<IExchangeService>(binding, endpoint);

IExchangeService client = factory.CreateChannel();

Console.WriteLine(client.GetServiceStatus());

Console.Write("Enter currency code, for example USD, EUR, GBP: ");
string? code = Console.ReadLine();

if (string.IsNullOrWhiteSpace(code))
{
    code = "USD";
}

decimal rate = await client.GetExchangeRateAsync(code);
Console.WriteLine($"Current {code.ToUpper()} exchange rate from NBP API: {rate} PLN");

((IClientChannel)client).Close();
factory.Close();
