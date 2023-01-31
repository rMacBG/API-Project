using API_Models.Context;
using API_Project.Controllers;
using API_Project.Services;
using API_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API_Models.Models;
using API_Models.Models.AppSettings;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Net.Http.Headers;
using API_Project.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
{
    const string name = "token";

    options.AddSecurityDefinition(name, new OpenApiSecurityScheme
    {
        Description = "Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
    }
   );

    options.OperationFilter<SecurityRequirementsOperationFilter>(true, name);
}
);

builder.Services
    .AddDbContext<LibContext>(options => options
.UseSqlServer(connectionString, b => b
.MigrationsAssembly("API Project")));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<UserManager<User>>();
//builder.Services.AddTransient<ICSVService, CSVService>();
builder.Services
    .AddIdentity<User, Role>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 3;
        options.Password.RequiredUniqueChars = 1;
    })
    .AddEntityFrameworkStores<LibContext>();

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"]);
builder.Services.AddAuthentication( o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.SaveToken= false;
        o.TokenValidationParameters = new TokenValidationParameters()
        {
            
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            ValidAudience = builder.Configuration["Jwt:ValidAudience"],
             ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
          
            IssuerSigningKey = new SymmetricSecurityKey(key)
            
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 app.UseCors();
await app.SeedRolesAsync();
await app.SeedUsersAsync();
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
