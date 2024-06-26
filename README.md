<!-- PROJECT LOGO -->
<br />
<div align="center">

  <h2 align="center">Financial Service</h2>

  <p align="center">
    Search finance information easly!
    <br />
  </p>
  <a href="https://github.com/othneildrew/Best-README-Template">
    <img src="github_res/main_page.png" alt="main">
  </a>
</div>

<!-- ABOUT THE PROJECT -->

## Built With

### Frontend

- React
- TypeScript, HTML, CSS
- Tailwind

### Backend

- ASP.NET Web API
- C#
- Entity Framework Core
- JWT Authorization
- Migrations

### Database

- PostgreSQL
- Microsoft SQL Server - Optional

### Also

- Docker (Docker Compose)
- Financial Modeling Prep API

<!-- GETTING STARTED -->

## Installation

1. Get a free API Key at [https://site.financialmodelingprep.com](https://site.financialmodelingprep.com)
2. Clone the repo
   ```sh
   git clone https://github.com/4qiz/FinancialWebService.git
   ```
3. Enter your API key in `frontend/.env`
   ```js
   REACT_APP_API_KEY = ENTER_YOUR_API;
   ```
4. Enter your API key in `api/appsettings.json`
   ```js
   "FMPKey" : "ENTER_YOUR_API";
   ```
5. Install and run Docker
6. Go to FinancialWebService directory in shell and write the command
   ```sh
   docker-compose up
   ```
7. - http://localhost:5001 - Frontend main page

   - http://localhost:5000/swagger/index.html - API Swagger

<!-- USAGE EXAMPLES -->

## Usage

1 Register a new account on the Sign in tab

2 Login in to your account

3 Search companies by ticker

![Main Screen](/github_res/search_page.png?raw=true ".")

4 Click Add button to add company to favorites

5 Click on the company name to view information about it

![Main Screen](/github_res/company_page.png?raw=true ".")

## Contact

Antipin Egor - ispp.ea@gmail.com
