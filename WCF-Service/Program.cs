using CoreWCF;
using CoreWCF.Configuration;
using WCF_Service;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://localhost:5000");
builder.Services.AddServiceModelServices();
builder.Services.AddSingleton<ExchangeService>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<ExchangeService>();
    serviceBuilder.AddServiceEndpoint<ExchangeService, IExchangeService>(
        new BasicHttpBinding(),
        "/ExchangeService");
});

app.MapGet("/", () => "Currency Exchange Office service is running. Use /ExchangeService for SOAP endpoint.");

app.Run();
