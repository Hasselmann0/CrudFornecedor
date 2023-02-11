using CrudFornecedor.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudFornecedor.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<Fornecedor> Fornecedores{ get; set; }
    }
}