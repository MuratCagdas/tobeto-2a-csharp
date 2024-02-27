
using Business.DependencyResolvers;
using Core.CrossCuttingConcerns.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddBusinessServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Core.Utilities.Security.JWT.TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Core.Utilities.Security.JWT.TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true, // Issuer'ý validate etmeli mi?
        ValidateAudience = true,// Audience'ý validate etmeli mi?
        ValidateLifetime = true, // Süreyi validate etmeli mi?
        ValidateIssuerSigningKey = true, // Security key validate etmeli mi?
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)), // Valid security key deðeri
        ValidIssuer = tokenOptions.Issuer,// Valid Issuer deðeri
        ValidAudience = tokenOptions.Audience,// Valid Audience deðeri
    };
}); // jwt add for authentication

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Middleware Exception
//if (app.Environment.IsProduction())
app.UseGlobalExceptionHandling();


app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
