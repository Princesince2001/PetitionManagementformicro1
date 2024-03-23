using Microsoft.EntityFrameworkCore;
using PetitionManagementSystem.Connection;
using System;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PetitionManagementDBContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version())));
builder.Services.AddCors(options =>

{

    options.AddPolicy(name: "_myAllowSpecificOrigins",

    policy =>

    {

        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyMethod();

    }

    );

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("_myAllowSpecificOrigins");



app.Run();
