using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceCompraUsuario
{
    public interface ICompraUsuario : IGeneric<CompraUsuario>
    {
        public Task<int> QuantidadeProdutoCarrinhoUsuario(string userId);
    }
}
