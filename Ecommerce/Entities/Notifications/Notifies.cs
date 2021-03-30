using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notificacoes = new List<Notifies>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string mensagem { get; set; }

        [NotMapped]
        public List<Notifies> Notificacoes;

        public bool ValidarPropriedadeString(string valor, string nomepropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomepropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    mensagem = "Campo obrigatório",
                    NomePropriedade = nomepropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int valor, string nomepropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomepropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomepropriedade
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeDecimal(decimal valor, string nomepropriedade)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomepropriedade))
            {
                Notificacoes.Add(new Notifies
                {
                    mensagem = "Valor deve ser maior que 0",
                    NomePropriedade = nomepropriedade
                });

                return false;
            }

            return true;
        }
    }
}
