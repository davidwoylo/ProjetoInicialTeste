using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Notificacoes
{
    /// <summary>
    /// Classe notificação
    /// </summary>
    public class Notificacao
    {
        public Guid Id { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public int Versao { get; private set; }

        public Notificacao(string _chave, string _valor)
        {
            Id = Guid.NewGuid();
            Versao = 1;
            Chave = _chave;
            Valor = _valor;
        }
    }
}
