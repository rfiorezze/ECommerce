using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceCompraUsuario
    {
        Task AddProdutoCarrinho(string userId, CompraUsuario compra);
    }
}
