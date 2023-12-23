using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.DTOs
{
    public class FiltroProdutoDTO
    {
        [DefaultValue(10)]
        public int? QtdPagina { get; set; }
        public bool? Situacao { get; set; }
        public string CodigoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
