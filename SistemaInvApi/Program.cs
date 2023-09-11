using SistemaInvApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar controladores y vistas al contenedor de servicios
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<InventarioTicsContext>();

//Agregando cors
builder.Services.AddCors(options =>
{
    //NUEVA POLITICA
    options.AddPolicy("NuevaPolitica", app =>
    {
        //PERMITE CUALQUIER ORIGEN
        app.AllowAnyOrigin()
        //PERMIE CUALQUIER CABECERA
        .AllowAnyHeader()
        //PERMITE CUALQUIER METODO
        .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//HABILITAR LA POLITICA DE CORS PARA PODER USARLA
app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
