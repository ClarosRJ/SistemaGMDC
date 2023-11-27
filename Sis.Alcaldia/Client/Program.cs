using Blazored.SessionStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http.Features;
using MudBlazor.Services;
using Sis.Alcaldia.Client;
using Sis.Alcaldia.Client.Servicios.Contratos;
using Sis.Alcaldia.Client.Servicios.Implementacion;
using Sis.Alcaldia.Client.Utilidades;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7127/") });

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IRolUsuarioServicio, RolUsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IPisoServicio, PisoServicio>();
builder.Services.AddScoped<IClienteServicio, ClienteServicio>();
builder.Services.AddScoped<IHabitacionServicio, HabitacionServicio>();
builder.Services.AddScoped<IRecepcionServicio, RecepcionServicio>();
builder.Services.AddScoped<IDashBoardServicio, DashBoardServicio>();
builder.Services.AddScoped<IColaboradoresServicio, ColaboradoresServicio>();
builder.Services.AddScoped<IConfigContabilidadServicio, ConfigContabilidadServicio>();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();

//builder.Services.Configure<FormOptions>(options =>
//{
//    options.MultipartBodyLengthLimit = 600000; // Cambia este valor seg�n tus necesidades
//});

builder.Services.AddMudServices();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
