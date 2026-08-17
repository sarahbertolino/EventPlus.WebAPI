using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do EF Core - Banco de Dados
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registra o serviço de controller(mapeia automaticamente os controllers da pasta /Controllers)
builder.Services.AddControllers();

// Injeção de dependência
// AddScoped significa que uma instância nova é criada por requisição HTTP
// Isso garante que cada requisição tenha seu próprio contexto isolado
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();

builder.Services.AddScoped<ITipoEvento, TipoEventoRepository>();

builder.Services.AddScoped<IUsuario, UsuarioRepository>();

var app = builder.Build();


app.MapControllers();
//Mapeia as rotas definidas nos Controllers com os atributos [Route]: api/[controller]

app.Run();
