using API.Models.TipoDespesa;
using API.Infra.TipoDespesa;
using API.Services.TipoDespesa;
using API.Models.Fornecedor;
using API.Infra.Fornecedor;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using API.Infra.Injector;
using API.Models.TipoDespesa.TipoDespesa;
using API.Models;
using API.Infra.Fornecedor.Fornecedor;
using API.Services.Fornecedor;

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
            serviceDescriptors.AddTransient<IFornecedorRepositorio, FornecedorRepositorio>();
            serviceDescriptors.AddTransient<IFornecedorService, FornecedorService>();
        }
    }
}