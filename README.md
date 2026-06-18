# Currency Exchange Office

## Course Name
Network Application Development

## Project Title
Currency Exchange Office System

## Author
Nilay Ipek

## Student ID
66273

## Short Description
This project is a network-based currency exchange office system developed for the Network Application Development course.

The system contains a WCF-style Web Service implemented with CoreWCF. The service retrieves real exchange rates from the National Bank of Poland API and exposes methods that can be consumed by a client application.

Implemented functionality:
- WCF/CoreWCF Web Service
- Console client application
- Service status method
- Current exchange rate retrieval by currency code, for example USD, EUR, GBP
- Historical exchange rate retrieval by date
- Simulated buying of foreign currency
- Simulated selling of foreign currency
- SQL database schema for future users, balances and transactions
- Short project documentation

## Project Structure

```text
CurrencyExchangeOffice
|
|-- WCF-Service
|   |-- Source code of the Web Service
|
|-- Client-Application
|   |-- Console client application
|
|-- Database
|   |-- SQL schema script
|
|-- Documentation
|   |-- Short project description
|
|-- README.md
```

## How to Run

### Requirements
- .NET 8 SDK
- Visual Studio 2022, JetBrains Rider or Visual Studio Code
- Internet connection for NBP API access

### Run Web Service

Open a terminal in the project folder:

```bash
cd WCF-Service
dotnet restore
dotnet run
```

The service runs on:

```text
http://localhost:5000/ExchangeService
```

### Run Client Application

Open another terminal:

```bash
cd Client-Application
dotnet restore
dotnet run
```

The console application connects to the service and tests:
- service communication
- current exchange rate retrieval
- buying currency
- selling currency

## External API
The project uses the National Bank of Poland API:

```text
https://api.nbp.pl/api/exchangerates/rates/a/{currencyCode}/?format=json
```

Example:

```text
https://api.nbp.pl/api/exchangerates/rates/a/usd/?format=json
```

Historical rate example:

```text
https://api.nbp.pl/api/exchangerates/rates/a/usd/2026-03-04/?format=json
```

## Current Stage
The project contains a working service structure, NBP API integration, console client, database schema and documentation. The WPF client and full database persistence can be added as future improvements.
