using Gateway.Api.Consumers;
using Gateway.Api.Hubs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSignalR();
builder.Services.AddSingleton<IWorker, Worker>();


var origins = builder.Configuration.GetSection("Origins").Get<string[]>();

builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder => { builder.WithOrigins(origins).AllowAnyMethod().AllowAnyHeader().AllowCredentials(); }));

var app = builder.Build();

app.Services.GetRequiredService<IWorker>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapHub<ParamHub>("/demoHub"); });

app.Run();

