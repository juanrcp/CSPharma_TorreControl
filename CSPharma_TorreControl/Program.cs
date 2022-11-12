using EntityBasicoDAL.cspharma_informacional;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Esto lo añadimos para que reconozla los @. 
builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews();

//AÑADIMOS EL SERVICIO PARA MOSTAR LA VISTA
builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<CspharmaInformacionalContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("EFCConexion"));
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
