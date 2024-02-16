using Microsoft.EntityFrameworkCore;
using ProyectoCrud.DAL;
using ProyectoCrud.DAL.BD_Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Conection string sql
builder.Services.AddDbContext<BdMilesCarRentalContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSqlBrowerLocal")));
#endregion



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

