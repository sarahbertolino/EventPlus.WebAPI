using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuração do EF Core - Banco de Dados
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Registra o serviço de controller(mapeia automaticamente os controllers da pasta /Controllers)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;   
});

// Injeção de dependência
// AddScoped significa que uma instância nova é criada por requisição HTTP
// Isso garante que cada requisição tenha seu próprio contexto isolado
builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();

builder.Services.AddScoped<ITipoEvento, TipoEventoRepository>();

builder.Services.AddScoped<IUsuario, UsuarioRepository>();

builder.Services.AddScoped<IInstituicao, InstituicaoRepository>();

//Autenticação JWT
//Configura como a API vai validar os tokens recebidos nas requisições
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new
        Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //valida quem emitiu o token
        ValidateIssuer = true,
        ValidIssuer = "EventPlus.WebAPI",
        //valida para quem o token foi emitido
        ValidateAudience = true,
        ValidAudience = "EventPlus.WebAPI",
        //valida se o token ainda está dentro do prazo de validade
        ValidateLifetime = true,
        //define a tolenrancia de clock entre servidores
        ClockSkew = TimeSpan.FromMinutes(5),
        //chave secreta utilizada para validar a assinatura do token
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes("eventos-chave-autenticacao-webapi-dev")
            )
    };
}
);

//Registra o serviço de autorização (necessário para [Autorize] funcionar)
builder.Services.AddAuthorization();

var app = builder.Build();

//Redireciona Http para Https automaticamente
app.UseHttpsRedirection();

//Ativa a autenticação
app.UseAuthentication();

//Ativa a autorização
app.UseAuthorization();

app.MapControllers();
//Mapeia as rotas definidas nos Controllers com os atributos [Route]: api/[controller]

app.Run();
