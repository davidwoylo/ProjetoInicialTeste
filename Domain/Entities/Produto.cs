using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string DescricaoProduto { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
