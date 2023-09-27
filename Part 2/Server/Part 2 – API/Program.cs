using Part_2___API.Interfaces;
using Part_2___API.Services;
// global using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// DotEnv.Load();

var configuration = builder.Configuration;
configuration.AddUserSecrets<Program>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGitHubApiService, GitHubApiService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddHttpClient();

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("CorsPolicy", options =>
    {
        options.AllowAnyMethod().AllowAnyHeader()
        .AllowAnyOrigin().WithOrigins("http://localhost:4200");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();
