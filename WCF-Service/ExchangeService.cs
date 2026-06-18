using System.Text.Json;

namespace WCF_Service;

public class ExchangeService : IExchangeService
{
    private readonly HttpClient _httpClient = new HttpClient();

    public string GetServiceStatus()
    {
        return "Currency Exchange Office WCF Service is running.";
    }

    public async Task<decimal> GetExchangeRateAsync(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
            throw new ArgumentException("Currency code cannot be empty.");

        currencyCode = currencyCode.Trim().ToLower();
        string url = $"https://api.nbp.pl/api/exchangerates/rates/a/{currencyCode}/?format=json";

        string json = await _httpClient.GetStringAsync(url);
        using JsonDocument document = JsonDocument.Parse(json);

        decimal rate = document
            .RootElement
            .GetProperty("rates")[0]
            .GetProperty("mid")
            .GetDecimal();

        return rate;
    }
}
