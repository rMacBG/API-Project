using API_Models.Configs;
using API_Models.Context;
using API_Project.Controllers;
using API_Project.Services;
using API_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity.UI;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibContext>(options => options
.UseSqlServer(connectionString, b => b.MigrationsAssembly("API Project")));
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddIdentity<IdentityUser>(o => o.options.SignIn.RequiredEmailConfirmedAccountFalse).
//    addEntityFrameworkStores<LibContext>();
//builder.Services.AddIdentityCore<IdentityUser>().AddEntityFrameworkStores<LibContext>
 //   ().AddDefaultTokenProviders();
 
builder.Services.AddAuthentication( o =>
    {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(o =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtConfig:Secret").Value);
        o.SaveToken= true;

        o.TokenValidationParameters = new TokenValidationParameters()
        {
           ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JwtConfig:ValidAudience"],
            ValidIssuer = builder.Configuration["JwtConfig:ValidIssuer"],
            RequireExpirationTime = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key)
            //Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Secret"]
        };
    });
builder.Services.AddDefaultIdentity<IdentityUser>(o => o.SignIn.RequireConfirmedEmail = true).AddEntityFrameworkStores<LibContext>();
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
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
