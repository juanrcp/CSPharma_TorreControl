<<<<<<< HEAD
=======
using EntityBasicoDAL.cspharma_informacional;
using Microsoft.EntityFrameworkCore;
>>>>>>> e5de13ec8660ebe848d93f77819343ba0ceedf23
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// Add services to the container.
builder.Services.AddControllersWithViews();
=======
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
>>>>>>> e5de13ec8660ebe848d93f77819343ba0ceedf23

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
