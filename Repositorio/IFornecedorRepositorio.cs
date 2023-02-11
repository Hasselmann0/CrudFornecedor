using CrudFornecedor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFornecedor.Repositorio
{
    public interface IFornecedorRepositorio
    {
        Fornecedor ListarPorId(int id);
        List<Fornecedor> BuscarTodos();
        Fornecedor Adicionar(Fornecedor fornecedor);
        Fornecedor Atualizar(Fornecedor fornecedor);
        bool Apagar(int id);
    }
}