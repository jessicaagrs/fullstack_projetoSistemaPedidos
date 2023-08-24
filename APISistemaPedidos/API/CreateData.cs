using API.Models.Fornecedor;
using API.Services.Fornecedor;

namespace API.Create
{
    public class CreateData
    {
        private IFornecedorService _fornecedorService;

        public CreateData(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        public void CriarDados()
        {
            var exemplo1 = new Fornecedores()
            {
                RazaoSocial = "Empresa ABC",
                Cnpj = "00000000000191",
                TipoDespesaId = 1
            };

            var exemplo2 = new Fornecedores()
            {
                RazaoSocial = "Empresa FGH",
                Cnpj = "00000000000191",
                TipoDespesaId = 2
            };

            var exemplo3 = new Fornecedores()
            {
                RazaoSocial = "Empresa WYZ",
                Cnpj = "00000000000191",
                TipoDespesaId = 3
            };

            _fornecedorService.Adicionar(exemplo1);
            _fornecedorService.Adicionar(exemplo2);
            _fornecedorService.Adicionar(exemplo3);
        }

    }
}
