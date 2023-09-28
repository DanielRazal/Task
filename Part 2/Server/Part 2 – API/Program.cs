using Part_2___API.Interfaces;
using Part_2___API.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
configuration.AddUserSecrets<Program>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IGitHubService, GitHubService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddHttpClient();

var angularCors = "http://localhost:4200";

builder.Services.AddCors(setup =>
{
    setup.AddPolicy("CorsPolicy", options =>
    {
        options.AllowAnyMethod().AllowAnyHeader()
        .AllowAnyOrigin().WithOrigins(angularCors);
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

app.UseSession();

app.MapControllers();

app.Run();
