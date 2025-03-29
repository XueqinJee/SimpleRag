using ClassLibrary.Services;
using Microsoft.EntityFrameworkCore;
using Model;
using Simepe.App.Components;
using Tools;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAntDesign();

builder.Services.AddDbContext<MyDbContext>(options => {
    options.UseSqlite("Data Source=mydb.db");
});
builder.Services.AddScoped<KnowledgeService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseAntiforgery();
app.UseStatusCodePagesWithRedirects("/404");
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
