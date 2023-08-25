using API.Models.Fornecedor;
using API.Models.Produto;
using API.Models.TipoDespesa;
using System.Text.RegularExpressions;

namespace API.Services.Fornecedor
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly ITipoDespesaRepositorio _tipoDespesaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public FornecedorService(IFornecedorRepositorio fornecedorRepositorio, ITipoDespesaRepositorio tipoDespesaRepositorio, IProdutoRepositorio produtoRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
            _tipoDespesaRepositorio = tipoDespesaRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public Fornecedores Adicionar(Fornecedores fornecedor)
        {
            if (fornecedor is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var cnpjValido = ValidarCnpjFornecedor(fornecedor);

            if(!cnpjValido)
                throw new Exception("O número de caracteres informado para o CNPJ/CPF está incorreto.");

            fornecedor.Validar();
            var fornecedores = _fornecedorRepositorio.Adicionar(fornecedor);
            return fornecedores;
        }

        public Fornecedores Atualizar(Fornecedores fornecedor)
        {
            if (fornecedor is null)
                throw new Exception("Dados inválidos, favor revisar o preenchimento");

            var cnpjValido = ValidarCnpjFornecedor(fornecedor);

            if (!cnpjValido)
                throw new Exception("O número de caracteres informado para o CNPJ/CPF está incorreto.");

            fornecedor.Validar();
            var fornecedores = _fornecedorRepositorio.Atualizar(fornecedor);
            return fornecedores;
        }

        public Fornecedores Remover(int fornecedorId)
        {
            var fornecedorVinculado = EmUso(fornecedorId);
            if (fornecedorVinculado)
                throw new Exception("O fornecedor está vinculado a um produto e não pode ser removido.");

            if (fornecedorId > 0)
            {
                var fornecedor = _fornecedorRepositorio.Remover(fornecedorId);
                return fornecedor;
            }

            return null;
        }

        public IEnumerable<Fornecedores> ObterTodos()
        {
            return _fornecedorRepositorio.ObterTodos();
        }

        private bool ValidarCnpjFornecedor(Fornecedores fornecedor)
        {
            string cnpjNumeros = Regex.Replace(fornecedor.Cnpj, @"[.\-/]", "");
            fornecedor.Cnpj = cnpjNumeros;

            if (cnpjNumeros.Length == 11 || cnpjNumeros.Length == 14) return true; return false;
        }

        private bool EmUso(int fornecedorId)
        {
            var fornecedorEmUso = _produtoRepositorio.ObterTodos().Where(f => f.Fornecedores?.Id == fornecedorId).Any();
            if(fornecedorEmUso) return true; return false;
        }
    }
}
