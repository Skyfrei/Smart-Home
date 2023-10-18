using HomeLayoutService.AsyncDataService;
using HomeLayoutService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HomeLayoutDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("HomeLayoutCon")));
Console.WriteLine("Using sql");



builder.Services.AddScoped<IHomeLayoutRepo, HomeLayoutRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();


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
InMem.PrepDb(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
