using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceProduct
    {
        Task AddProduct(Produto product);

        Task UpdateProduct(Produto product);

        Task<List<Produto>> ListarProdutosComEstoque();

    }
}
