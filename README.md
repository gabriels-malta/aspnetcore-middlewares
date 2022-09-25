# AspNetCore Middlewares

## Description
These AspNetCore middlewares act over HTTP requests/responses aiming to nurture communication between microservices.

All the middlewares are written using
- .net6
- C# 10


## Using
The middlewares provide an extension methods that allows you to attach them in the _IApplicationBuilder_, at the _Program.cs_.
```
var app = builder.Build();

app.UseCorrelation();

app.UseServiceInfo(config =>
{
    config.ServiceName = "weather_forecast_app";
    config.ServiceVersion = (1, 0);
});
```