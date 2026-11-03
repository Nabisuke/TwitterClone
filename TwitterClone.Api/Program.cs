using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<ITweetRepository, TweetRepository>();
builder.Services.AddScoped<ITweetService>(serviceProvider =>
    new TweetService(
        serviceProvider.GetRequiredService<ITweetRepository>(),
        builder.Configuration.GetValue<int>("TwitterSettings:MaxTweetLength")));

var app = builder.Build();

app.MapOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapGet("/status", () => Results.Ok(new { status = "TwitterClone API is running" }));
app.MapGet("/", () => Results.Content(
    """
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <title>TwitterClone API Swagger</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swagger-ui-dist@5/swagger-ui.css" />
        <style>
            html { box-sizing: border-box; overflow: -moz-scrollbars-vertical; overflow-y: scroll; }
            *, *:before, *:after { box-sizing: inherit; }
            body { margin: 0; background: #fafafa; }
            #swagger-ui { max-width: 1200px; margin: 20px auto; }
        </style>
    </head>
    <body>
        <div id="swagger-ui"></div>
        <script src="https://cdn.jsdelivr.net/npm/swagger-ui-dist@5/swagger-ui-bundle.js"></script>
        <script>
            window.onload = function () {
                SwaggerUIBundle({
                    url: "/openapi/v1.json",
                    dom_id: '#swagger-ui',
                    deepLinking: true,
                    presets: [SwaggerUIBundle.presets.apis, SwaggerUIBundle.SwaggerUIStandalonePreset],
                    layout: "BaseLayout",
                    persistAuthorization: true
                });
            };
        </script>
    </body>
    </html>
    """,
    "text/html"));

app.MapControllers();

app.Run();

