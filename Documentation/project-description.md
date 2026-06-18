# Project Documentation

## System Architecture
The system simulates an online currency exchange office. It is divided into separate components:

1. Web Service
   - Provides business logic.
   - Retrieves current and historical exchange rates from the National Bank of Poland API.
   - Exposes methods for client applications.
   - Implements simulated buy and sell operations.

2. Client Application
   - Console client prepared for testing service communication.
   - Connects to the WCF/CoreWCF service using BasicHttpBinding.
   - Displays exchange rates and example transaction results.

3. Database
   - SQL schema prepared for users, currency balances and transaction history.
   - Can be connected to the service in a later stage.

## Implemented Functionality
- Service status check.
- Currency exchange rate retrieval by currency code.
- Historical exchange rate retrieval by currency code and date.
- Buying foreign currency for a PLN amount.
- Selling foreign currency for PLN.
- NBP API integration.
- Console client consuming service methods.

## Service Methods

```csharp
string GetServiceStatus();
Task<decimal> GetExchangeRateAsync(string currencyCode);
Task<decimal> GetHistoricalExchangeRateAsync(string currencyCode, string date);
Task<ExchangeResult> BuyCurrencyAsync(string currencyCode, decimal plnAmount);
Task<ExchangeResult> SellCurrencyAsync(string currencyCode, decimal foreignCurrencyAmount);
```

## Planned Functionality
- WPF graphical client.
- User account registration.
- Virtual account balance top-up.
- Persistent transaction history.
- Persistent currency balances.
- Reports for historical exchange rates.
