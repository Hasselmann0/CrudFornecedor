using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFornecedor.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do fornecedor"), Column("Nome", TypeName = "nvarchar(100)")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CNPJ do fornecedor"), Column("CNPJ", TypeName = "nvarchar(14)")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "Selecione a especialidade do fornecedor")]
        public string Especialidade { get; set; }  
    }
}