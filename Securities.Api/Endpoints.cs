using Microsoft.AspNetCore.Builder;
using Securities.Lib;

namespace Securities.Api;

public static class Endpoints
{
    public static void ConfigureWeatherForecastEndpoint(IEndpointRouteBuilder endpoints)
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        endpoints.MapGet("/weatherforecast", () =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
    }

    public static void ConfigureSecuritiesEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/securities", async (ISecuritiesService securitiesService) =>
            {
                var securities = securitiesService.GetSecurities();
                return securities.Value;
            })
            .WithName("GetSecurities")
            .WithOpenApi();

        endpoints.MapGet("/security/{ticker}", async (ISecuritiesService securitiesService, string ticker) =>
            {
                var securities = securitiesService.GetSecurity(ticker);
                return securities.Value;
            })
            .WithName("GetSecurity")
            .WithOpenApi();
    }
}