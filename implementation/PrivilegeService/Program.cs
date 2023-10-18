using Microsoft.EntityFrameworkCore;
using PrivilegeService.AsyncCommunication;
using PrivilegeService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPrivilegeRepo, PrivilegeRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMessageBus, MessageBus>();

builder.Services.AddDbContext<PrivilegeDataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("PrivilegeCon")));
Console.WriteLine("Using sql");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

PrepDatabase.PrepPopulation(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
