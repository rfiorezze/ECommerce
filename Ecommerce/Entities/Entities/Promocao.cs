using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entities
{
    public class Promocao
    {
        public int IdPromocao { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Promocao> ListaPromocoes
        {
            get
            {
                return new List<Promocao>
            {
                new Promocao { IdPromocao = 0, Descricao = "Selecione..." },
                new Promocao { IdPromocao = 1, Descricao = "3 Por 10" },
                new Promocao { IdPromocao = 2, Descricao = "Leve 2 Pague 1" }
            };
            }
        }
    }
}

