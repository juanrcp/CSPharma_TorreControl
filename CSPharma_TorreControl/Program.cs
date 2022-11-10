var builder = WebApplication.CreateBuilder(args);

//Añadimos los servicios que nos interesa al constructor
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<entityBasicoContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("EFCConexion"))
    );

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
