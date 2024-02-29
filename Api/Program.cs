using Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddAutoMapper();
builder.Services.AddDependenciesInjection();


var app = builder.Build();
app.InitializeDbTestDataAsync();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
