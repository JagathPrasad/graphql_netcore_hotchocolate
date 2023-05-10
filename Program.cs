using GraphQL.GraphQL;
using GraphQL.Service;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using GraphQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GraphQL;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(x =>
               {
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = "http://mysite.com",
                       ValidAudience = "http://mysite.com",
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_12345"))
                   };
                   x.Events = new JwtBearerEvents
                   {
                       OnAuthenticationFailed = context =>
                       {
                           if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                           {
                               context.Response.Headers.Add("Token-Expired", "true");
                           }
                           return Task.CompletedTask;
                       }
                   };
               });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ImmihubContext>(
    options => options.UseSqlServer("Server=DESKTOP-DVS65KG\\SQLEXPRESS;Database=Immihub;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));
//builder.Services.AddScoped<Query>();
//builder.Services.AddScoped<Mutation>();
builder.Services.AddTransient<JourneyService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<VisaTypeService>();
builder.Services.AddTransient<FAQService>();
//builder.Services.AddGraphQL(c => SchemaBuilder.New().AddServices(c).AddType<GraphQLTypes>()
//                                                            .AddQueryType<Query>()
//                                                            .AddMutationType<Mutation>()
//                                                             .Create());

//builder.Services.AddScoped<ImmihubContext>(sp =>
//    sp.GetRequiredService<IDbContextFactory<ImmihubContext>>().CreateDbContext());

//builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddFiltering().AddProjections().AddSorting();
//builder.Services.AddGraphQLServer().AddQueryType<UserService>();//working fine 
builder.Services.AddGraphQLServer().RegisterService<JourneyService>()
    .RegisterService<UserService>().RegisterService<VisaTypeService>().RegisterService<FAQService>()
    .AddQueryType<Query>().AddMutationType<Mutation>().AddProjections().AddFiltering().AddSorting()
    .AddAuthorization();
    //.AddInMemorySubscriptions();//working fine 
                                                                          // CORS
var cors = Environment.GetEnvironmentVariable("CORS");
var origins = cors?.Split(',', StringSplitOptions.RemoveEmptyEntries);

if (origins == null || origins.Length == 0)
{
    origins = new string[] { "http://localhost", "http://localhost:3000" };
}

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    builder =>
    {
        builder.WithOrigins(origins)
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
//var signingKey = new SymmetricSecurityKey(
//            Encoding.UTF8.GetBytes("MySuperSecretKey"));

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters =
//            new TokenValidationParameters
//            {
//                ValidIssuer = "https://auth.chillicream.com",
//                ValidAudience = "https://graphql.chillicream.com",
//                ValidateIssuerSigningKey = true,
//                IssuerSigningKey = signingKey
//            };
//    });
//builder.Services.AddHttpContextAccessor();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/api",
    Path = "/playground"
});
//app.UseWebSockets();
app.MapGraphQL("/graphql");
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
