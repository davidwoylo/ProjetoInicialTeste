using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ViewModels
{
    public class ProdutoViewModel
    {
        [Required]
        public string DescricaoProduto { get; set; }
        [Required]
        public bool Situacao { get; set; }
        [Required]
        public DateTime DataFabricacao { get; set; }
        [Required]
        public DateTime DataValidade { get; set; }
        [Required]
        public string CodigoFornecedor { get; set; }
        [Required]
        public string DescricaoFornecedor { get; set; }
        [Required]
        public string CnpjFornecedor { get; set; }
    }
}
