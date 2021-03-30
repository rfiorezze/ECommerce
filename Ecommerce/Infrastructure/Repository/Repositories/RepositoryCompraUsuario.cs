using Domain.Interfaces.InterfaceCompraUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCompraUsuario : RepositoryGenerics<CompraUsuario>, ICompraUsuario
    {
        private readonly DbContextOptions<ContextBase> _optionsbuilder;
        public RepositoryCompraUsuario()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.CompraUsuario.CountAsync(c => c.UserId.Equals(userId) && c.Estado == EstadoCompra.Produto_Carrinho);
            }
        }
    }
}
