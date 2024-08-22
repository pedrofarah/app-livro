using livro.api.persistence;
using livro.api.domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddIdentityPersistence(builder.Configuration);

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddFluentValidationConfiguration();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
