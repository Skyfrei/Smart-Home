using NotificationService.Data;
using Microsoft.EntityFrameworkCore;
using NotificationService.SynchDataService.Http;
using NotificationService.AsyncCommunication;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Mine
builder.Services.AddScoped<INotificationRepo, NotificationRepo>();
builder.Services.AddHttpClient<INotificationDataClient, HttpNotificationDataClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMessageBus, MessageBus>();

//builder.Services.AddHostedService<MessageBusSubscriber>();

///====== Not mine

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<NotificationDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("NotifConn")));
    Console.WriteLine("Using sql");
}
else
{
    builder.Services.AddDbContext<NotificationDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
    Console.WriteLine("Using inmem");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PrepareDatabase.PrepPopulation(app, app.Environment.IsProduction());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Console.WriteLine($"---> NotificationService endpoint {builder.Configuration["NotificationService"]}");
app.Run();

