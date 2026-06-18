using System.Text.Json;

namespace WCF_Service;

public class ExchangeService : IExchangeService
{
    private static readonly HttpClient HttpClient = new();

    public string GetServiceStatus()
    {
        return "Currency Exchange Office WCF/CoreWCF Service is running.";
    }

    public async Task<decimal> GetExchangeRateAsync(string currencyCode)
    {
        string code = NormalizeCurrencyCode(currencyCode);
        string url = $"https://api.nbp.pl/api/exchangerates/rates/a/{code}/?format=json";
        return await ReadRateFromNbpAsync(url);
    }

    public async Task<decimal> GetHistoricalExchangeRateAsync(string currencyCode, string date)
    {
        string code = NormalizeCurrencyCode(currencyCode);

        if (!DateOnly.TryParse(date, out _))
        {
            throw new ArgumentException("Date must use format YYYY-MM-DD, for example 2026-03-04.");
        }

        string url = $"https://api.nbp.pl/api/exchangerates/rates/a/{code}/{date}/?format=json";
        return await ReadRateFromNbpAsync(url);
    }

    public async Task<ExchangeResult> BuyCurrencyAsync(string currencyCode, decimal plnAmount)
    {
        if (plnAmount <= 0)
        {
            throw new ArgumentException("PLN amount must be greater than zero.");
        }

        string code = NormalizeCurrencyCode(currencyCode).ToUpperInvariant();
        decimal rate = await GetExchangeRateAsync(code);
        decimal foreignAmount = Math.Round(plnAmount / rate, 2);

        return new ExchangeResult
        {
            CurrencyCode = code,
            ExchangeRate = rate,
            InputAmount = plnAmount,
            OutputAmount = foreignAmount,
            OperationType = "BUY",
            Message = $"Bought {foreignAmount} {code} for {plnAmount} PLN using rate {rate}."
        };
    }

    public async Task<ExchangeResult> SellCurrencyAsync(string currencyCode, decimal foreignCurrencyAmount)
    {
        if (foreignCurrencyAmount <= 0)
        {
            throw new ArgumentException("Currency amount must be greater than zero.");
        }

        string code = NormalizeCurrencyCode(currencyCode).ToUpperInvariant();
        decimal rate = await GetExchangeRateAsync(code);
        decimal plnAmount = Math.Round(foreignCurrencyAmount * rate, 2);

        return new ExchangeResult
        {
            CurrencyCode = code,
            ExchangeRate = rate,
            InputAmount = foreignCurrencyAmount,
            OutputAmount = plnAmount,
            OperationType = "SELL",
            Message = $"Sold {foreignCurrencyAmount} {code} for {plnAmount} PLN using rate {rate}."
        };
    }

    private static string NormalizeCurrencyCode(string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
        {
            throw new ArgumentException("Currency code cannot be empty.");
        }

        string code = currencyCode.Trim().ToLowerInvariant();

        if (code.Length != 3)
        {
            throw new ArgumentException("Currency code must contain 3 letters, for example USD, EUR or GBP.");
        }

        return code;
    }

    private static async Task<decimal> ReadRateFromNbpAsync(string url)
    {
        using HttpResponseMessage response = await HttpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("NBP API did not return an exchange rate for the selected currency/date.");
        }

        string json = await response.Content.ReadAsStringAsync();
        using JsonDocument document = JsonDocument.Parse(json);

        return document.RootElement
            .GetProperty("rates")[0]
            .GetProperty("mid")
            .GetDecimal();
    }
}
