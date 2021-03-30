using Domain.Interfaces.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCompraUsuario : IServiceCompraUsuario
    {
        private readonly ICompraUsuario _ICompraUsuario;
        private readonly IProduct _IProduct;


        public ServiceCompraUsuario(ICompraUsuario ICompraUsuario, IProduct IProduct)
        {
            _ICompraUsuario = ICompraUsuario;
            _IProduct = IProduct;
        }

        public async Task AddProdutoCarrinho(string userId, CompraUsuario compra)
        {
            var compraUsuarioExistente = _ICompraUsuario.List().Result.Find(c => c.IdProduto == compra.IdProduto && c.UserId == userId);

            if (compraUsuarioExistente != null)
            {
                compraUsuarioExistente.QtdCompra += compra.QtdCompra;
                await _ICompraUsuario.Update(compraUsuarioExistente);
            }
            else
                await _ICompraUsuario.Add(compra);
        }

    }
}
