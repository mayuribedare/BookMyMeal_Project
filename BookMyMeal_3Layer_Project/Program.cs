using BAL_BMM.Implementation;
using BAL_BMM.Interface;
using DAL_BMM.Implementation;
using DAL_BMM.Interface;
using DL_BMM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookMyMealContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sql-conn")));

builder.Services.AddTransient<ILoginBAL, LoginBAL>();
builder.Services.AddTransient<ILoginDAL, LoginDAL>();
builder.Services.AddTransient<IBookingBAL, BookingBAL>();
builder.Services.AddTransient<IBookingDAL, BookingDAL>();

builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader().
            AllowAnyMethod();
        });
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = "false",
        ValidAudience = "false",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")),
        ClockSkew = TimeSpan.Zero
    };

});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");

app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
