using Application;
using Application.Interfaces;
using Application.Services;
using Domain.Config;
using Domain.Exceptions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.AWS;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using WebAPI.Exceptions.ProblemDetailsHelpers;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
// https://docs.microsoft.com/en-us/visualstudio/code-quality/code-metrics-maintainability-index-range-and-meaning?view=vs-2022
// Add services to the container.
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cors 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });
});

// add dependencies -> database provider based on dev/production
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();


builder.Services.AddTransient<IEmailSyntaxValidator, EmailSyntaxValidator>();
builder.Services.AddTransient<IPasswordHashGenerator, PasswordHashGenerator>();
builder.Services.AddTransient<IRemoteDiskStorageService, AwsS3Service>();
builder.Services.AddTransient<ISubscriptionsService, SubscriptionsService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var jwtConfig = new JwtTokenConfig();

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtConfig.Issuer,
                        ValidAudience = jwtConfig.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

builder.Services.AddAutoMapper(Assembly.Load(nameof(Application)));

builder.Services.AddProblemDetails(options =>
{
    options.Map<UserAlreadyExistsException>(details =>
                    details.MapToProblemDetailsWithStatusCode(HttpStatusCode.Conflict));
    options.Map<UserEmailTakenException>(details =>
        details.MapToProblemDetailsWithStatusCode(HttpStatusCode.Conflict));

    options.Map<NullReferenceException>(details =>
        details.MapToProblemDetailsWithStatusCode(HttpStatusCode.BadRequest));
    options.Map<ArgumentException>(details =>
        details.MapToProblemDetailsWithStatusCode(HttpStatusCode.BadRequest));
    options.Map<NullReferenceException>(details =>
        details.MapToProblemDetailsWithStatusCode(HttpStatusCode.BadRequest));

    options.Map<AuthenticationFailedException>(details =>
        details.MapToProblemDetailsWithStatusCode(HttpStatusCode.Forbidden));

    options.Map<UserNotFoundException>(details =>
        details.MapToProblemDetailsWithStatusCode(HttpStatusCode.NotFound));

    options.Map<UnauthorizedAccessException>(details =>
        details.MapToProblemDetailsWithStatusCode(HttpStatusCode.Unauthorized));
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Enter token here.",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseProblemDetails();
app.UseAuthorization();
app.UseMiddleware<TokenMiddleware>();

app.MapControllers();
app.Run();
