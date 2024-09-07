using LocadoraDeVeiculos.Aplicacao.ModuloAutenticacao;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCombustivel;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloLocacao;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxa;
using LocadoraDeVeiculos.Dominio.ModuloAutenticacao;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCombustivel;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloTaxa;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCombustivel;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm.ModuloLocacao;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxa;
using LocadoraDeVeiculos.WebApp.Mapping;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace LocadoraDeVeiculos.WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<LocadoraDbContext>();

        builder.Services.AddScoped<IRepositorioGrupoAutomovel, RepositorioGrupoAutomovelEmOrm>();
        builder.Services.AddScoped<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();
        builder.Services.AddScoped<IRepositorioPlanoCobranca, RepositorioPlanoCobrancaEmOrm>();
        builder.Services.AddScoped<IRepositorioTaxa, RepositorioTaxaEmOrm>();
        builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEmOrm>();
        builder.Services.AddScoped<IRepositorioCondutor, RepositorioCondutorEmOrm>();
        builder.Services.AddScoped<IRepositorioConfiguracaoCombustivel, RepositorioConfiguracaoCombustivelEmOrm>();
        builder.Services.AddScoped<IRepositorioLocacao, RepositorioLocacaoEmOrm>();
        builder.Services.AddScoped<IRepositorioFuncionario, RepositorioFuncionarioEmOrm>();

        builder.Services.AddScoped<ServicoGrupoAutomovel>();
        builder.Services.AddScoped<ServicoAutomovel>();
        builder.Services.AddScoped<ServicoPlanoCobranca>();
        builder.Services.AddScoped<ServicoTaxa>();
        builder.Services.AddScoped<ServicoCliente>();
        builder.Services.AddScoped<ServicoCondutor>();
        builder.Services.AddScoped<ServicoCombustivel>();
        builder.Services.AddScoped<ServicoLocacao>();
        builder.Services.AddScoped<ServicoFuncionario>();

        builder.Services.AddScoped<FotoValueResolver>();
        builder.Services.AddScoped<GrupoAutomovelValueResolver>();
        builder.Services.AddScoped<TaxasSelecionadasValueResolver>();

        builder.Services.AddScoped<TaxasValueResolver>();
        builder.Services.AddScoped<CondutoresValueResolver>();
        builder.Services.AddScoped<VeiculosValueResolver>();
        builder.Services.AddScoped<ValorParcialValueResolver>();
        builder.Services.AddScoped<ValorTotalValueResolver>();
        builder.Services.AddScoped<EmpresaIdValueResolver>();

        builder.Services.AddScoped<ServicoAutenticacao>();

        builder.Services.AddIdentity<Usuario, Perfil>()
            .AddEntityFrameworkStores<LocadoraDbContext>()
            .AddDefaultTokenProviders();

        builder.Services.Configure<IdentityOptions>
        (options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;
        });

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "AspNetCore.Cookies";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.SlidingExpiration = true;
            });

        builder.Services.ConfigureApplicationCookie(op =>
        {
            op.LoginPath = "/Autenticacao/Login";
            op.AccessDeniedPath = "/Autenticacao/AcessoNegado";
        });

        builder.Services.AddAutoMapper(cfg =>
        {
            cfg.AddMaps(Assembly.GetExecutingAssembly());
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            // Faz com que a aplicação permita apenas conexões HTTPS em navegadores suportados
            app.UseHsts();
        }

        // Redireciona requisições HTTP para HTTPS
        app.UseHttpsRedirection();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}