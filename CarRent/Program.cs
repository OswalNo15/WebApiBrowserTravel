using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProyectoCrud.BLL.Service;
using ProyectoCrud.DAL;
using ProyectoCrud.DAL.BD_Context;
using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.DAL.Services;
using ProyectoCrud.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Conection string sql
builder.Services.AddDbContext<BdMilesCarRentalContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSqlBrowerLocal")));
#endregion


#region Inyeccion de dependencias
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IGenericRepository<Car>, CarRepository>();
builder.Services.AddScoped<IGenericRepository<Client>, ClientRepository>();
builder.Services.AddScoped<IGenericRepository<IdType>, IdTypeRepository>();
builder.Services.AddScoped<IGenericRepository<PreferenceClient>, PreferenceClientRepository>();
builder.Services.AddScoped<IGenericRepository<Preference>, PreferenceRepository>();
builder.Services.AddScoped<IGenericRepository<Reservation>, ReservationRepository>();
builder.Services.AddScoped<IGenericRepository<Role>, RoleRepository>();
builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();
#endregion

#region configuration of JTW
var key = builder.Configuration.GetValue<string>("JWTSettings:key");
var keyBytes = Encoding.ASCII.GetBytes(key);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };

});

#endregion

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.Run();

