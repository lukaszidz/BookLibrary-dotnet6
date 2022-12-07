using BookLibrary.App.Configuration;
using BookLibrary.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.Get<AppSettings>();
var infraSettings = builder.Configuration.Get<InfrastructureSettings>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(appSettings.Cors)
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddInfrastructure(infraSettings);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.Run();
