# Project Documentation

## System Architecture
The system simulates an online currency exchange office. It is divided into separate components:

1. Web Service
   - Provides business logic.
   - Retrieves current exchange rates from the National Bank of Poland API.
   - Exposes methods for client applications.

2. Client Application
   - Console client prepared for testing service communication.
   - Can be extended later to WPF.

3. Database
   - Folder prepared for future SQL schema and initialization scripts.
   - Planned data: users, balances, and transactions.

## Implemented Functionality
- Service status check.
- Currency exchange rate retrieval by currency code.
- NBP API integration structure.

## Planned Functionality
- User accounts.
- Virtual account balance top-up.
- Buying and selling currencies.
- Transaction history.
- Historical exchange rates.
