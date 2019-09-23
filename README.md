# FundosInvestimentos
Repository API Fundos de Investimentos

This project was generated with (.Net Core 2.2) (SDK 2.2.402) https://dotnet.microsoft.com/download/dotnet-core/2.2

# Config/Startup

- [Install Docker] (https://store.docker.com/editions/community/docker-ce-desktop-windows)
- [Install Git] (https://git-scm.com/downloads)
- Clone the project -> git clone --recursive https://github.com/jamilepiran/FundosInvestimentos.git
- Open the project folder 'FundosInvestimento'
- Open the terminal from the folder
- Execute the command -> docker-compose up

Optional:
Docker

# Development server

- Open the terminal
- Open the terminal and access the folder : cd FundosInvestimento.API
- Run 'dotnet run' for a dev server. Navigate to http://localhost:5000/swagger.

#Enable Migrations

- If the folder 'Migrations' don't exists, execute the command : Add-Migration FundosInvestimento, after execute Update-Database
- If the folder 'Migrations' already exists, only execute the command Update-Database inside the directory FundosInvestimentos.Infra.Data
