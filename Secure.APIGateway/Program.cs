using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthentication("IdentityServerApiKey")
    .AddJwtBearer("IdentityServerApiKey", options => 
    {
        options.Authority = "http://localhost:5155";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
        };
        options.RequireHttpsMetadata = false;
    });

builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});
app.UseOcelot().Wait();

app.UseHttpsRedirection();

app.Run();