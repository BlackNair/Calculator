using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

NLog.LogManager.Setup().LoadConfiguration(builder => {
    builder.ForLogger().FilterMinLevel(NLog.LogLevel.Info).WriteToConsole();
    builder.ForLogger().FilterMinLevel(NLog.LogLevel.Debug).WriteToFile(fileName: "file.txt");
});

app.Run();
