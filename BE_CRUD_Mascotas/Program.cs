using BE_CRUD_App_Allied.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
    builder => builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()));



//Add context

/*
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));

});
*/

//Add context


builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQLConnetion"));

});

/*
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext< AplicationDbContext >(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgresSQLConnetion")));
*/
 
/*
var connectionString = builder.Configuration.GetConnectionString("PostgresSQLConnetion");
builder.Services.AddDbContext<AplicationDbContext>(options =>
options.UseNpgsql(connectionString));
*/

// Automapper

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
