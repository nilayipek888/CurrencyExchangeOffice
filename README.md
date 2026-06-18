# Currency Exchange Office

## Course Name
Network Application Development

## Project Title
Currency Exchange Office System

## Author
Nilay Ipek

## Student ID
TODO: Write your student ID here

## Short Description
This project is a network-based currency exchange office system developed for the Network Application Development course.

The system contains a WCF-style Web Service responsible for currency exchange business logic. The service retrieves real exchange rates from the National Bank of Poland API and exposes methods that can be consumed by a client application.

Current implementation includes:
- WCF/CoreWCF Web Service
- Method for checking service status
- Method for retrieving exchange rates using currency code, for example USD, EUR, GBP
- Console client project structure
- Documentation folder

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
|   |-- SQL scripts if database is implemented later
|
|-- Documentation
|   |-- Short project description
|
|-- README.md
```

## How to Run

### Requirements
- .NET 8 SDK
- Visual Studio 2022 or JetBrains Rider
- Internet connection for NBP API access

### Run Web Service

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

## External API
The project uses the National Bank of Poland API:

```text
https://api.nbp.pl/api/exchangerates/rates/a/{currencyCode}/?format=json
```

Example:

```text
https://api.nbp.pl/api/exchangerates/rates/a/usd/?format=json
```

## Current Stage
Initial implementation prepared for laboratory submission. The project includes service architecture, exchange rate method, and client application structure.
