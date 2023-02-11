using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudFornecedor.Data;
using CrudFornecedor.Models;

namespace CrudFornecedor.Repositorio
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        private readonly BancoContext _context;

        public FornecedorRepositorio(BancoContext context)
        {
            _context = context;
        }

        public Fornecedor ListarPorId(int id)
        {
            return _context.Fornecedores.FirstOrDefault(x => x.Id == id);
        }

        public List<Fornecedor> BuscarTodos()
        {
            return _context.Fornecedores.ToList();
        }

        public Fornecedor Adicionar(Fornecedor fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();

            return fornecedor;
        }

        public Fornecedor Atualizar(Fornecedor fornecedor)
        {
            Fornecedor fornecedorDB = ListarPorId(fornecedor.Id);

            if(fornecedorDB == null) throw new System.Exception("Houve um erro na atualização do fornecedor!");

            fornecedorDB.Nome = fornecedor.Nome;
            fornecedorDB.CNPJ = fornecedor.CNPJ;
            fornecedorDB.Especialidade = fornecedor.Especialidade;

            _context.Fornecedores.Update(fornecedorDB);
            _context.SaveChanges();

            return fornecedorDB;
        }

        public bool Apagar(int id)
        {
            Fornecedor fornecedorDB = ListarPorId(id);

            if(fornecedorDB == null) throw new System.Exception("Houve um erro na deleção do fornecedor!");

            _context.Fornecedores.Remove(fornecedorDB);
            _context.SaveChanges();

            return true;
        }
    }
}