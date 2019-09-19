FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /

COPY . .
RUN dotnet publish FundosInvestimento.API/FundosInvestimento.API.csproj -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY --from=build-env FundosInvestimento.API/out/ .

RUN cp /usr/share/zoneinfo/America/Sao_Paulo /etc/localtime

ENTRYPOINT ["dotnet", "FundosInvestimento.API.dll"]