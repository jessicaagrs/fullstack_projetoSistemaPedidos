using API.Models.TipoDespesa;
using API.Infra.TipoDespesa;
using API.Services.TipoDespesa;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using API.Infra.Injector;
using API.Models.TipoDespesa.TipoDespesa;
using API.Models;

namespace Api
{
    public class ServiceRegister
    {
        public static void Register(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddSignalR();
            serviceDescriptors.AddSingleton<IUserIdProvider, NamedUserProvider>();
            serviceDescriptors.AddHttpContextAccessor();
            serviceDescriptors.AddSession();
            serviceDescriptors.AddDbContext<EFDBContext>();
            serviceDescriptors.AddTransient<ITipoDespesaRepositorio, TipoDespesaRepositorio>();
            serviceDescriptors.AddTransient<ITipoDespesaService, TipoDespesaService>();
        }
    }
}