using Domain.Interfaces.InterfaceProduct;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryProduct : RepositoryGenerics<Produto>, IProduct
    {
        private readonly DbContextOptions<ContextBase> _optionsbuilder;
        public RepositoryProduct()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Produto>> ListarProdutos(Expression<Func<Produto, bool>> exProduto)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Produto.Where(exProduto).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var produtosCarrinhoUsuario = await (from p in banco.Produto
                                                     join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                     where c.UserId.Equals(userId) && c.Estado == EstadoCompra.Produto_Carrinho
                                                     select new Produto
                                                     {
                                                         Id = p.Id,
                                                         Nome = p.Nome,
                                                         Descricao = p.Descricao,
                                                         Observacao = p.Observacao,
                                                         Valor = p.Valor,
                                                         QtdCompra = c.QtdCompra,
                                                         IdProdutoCarrinho = c.Id,
                                                         Url = p.Url,
                                                         ValorTotal = p.Valor * c.QtdCompra,
                                                         Promocao = p.Promocao
                                                     }).AsNoTracking().ToListAsync();

                foreach (var item in produtosCarrinhoUsuario)
                {
                    if (item.Promocao != 0)
                    {
                        //Recuperando descrição da promoção
                        Promocao promocao = new Promocao();
                        item.DescricaoPromocao = promocao.ListaPromocoes.Where(p => p.IdPromocao == item.Promocao).First().Descricao;

                        #region [Regra de negócio caso seja a promoção 3 por 10]
                        if (item.Promocao == 1 && item.QtdCompra >= 3)
                        {
                            var qtd = item.QtdCompra;
                            item.ValorTotal = 0;
                            var resto = qtd % 3;
                            if (resto == 0)
                                item.ValorTotal = (qtd / 3) * 10;
                            else
                            {
                                while (resto != 0)
                                {
                                    item.ValorTotal += item.Valor;
                                    qtd--;
                                    resto = qtd % 3;
                                }
                                item.ValorTotal += (qtd / 3) * 10;
                            }
                        }
                        #endregion

                        if (item.Promocao == 2 && item.QtdCompra >= 2)
                        {
                            item.ValorTotal = 0;
                            var qtd = item.QtdCompra;
                            if ((qtd % 2) == 0)
                                item.ValorTotal = item.Valor * (qtd / 2);
                            else
                            {
                                item.ValorTotal += item.Valor;
                                qtd--;
                                item.ValorTotal += item.Valor * (qtd / 2);
                            }
                        }
                    }
                }
                return produtosCarrinhoUsuario;
            }
        }


        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                var produtoCarrinhoUsuario = await (from p in banco.Produto
                                                    join c in banco.CompraUsuario on p.Id equals c.IdProduto
                                                    where c.IdProduto.Equals(idProdutoCarrinho) && c.Estado == EstadoCompra.Produto_Carrinho
                                                    select new Produto
                                                    {
                                                        Id = p.Id,
                                                        Nome = p.Nome,
                                                        Descricao = p.Descricao,
                                                        Observacao = p.Observacao,
                                                        Valor = p.Valor,
                                                        QtdCompra = c.QtdCompra,
                                                        IdProdutoCarrinho = c.Id,
                                                        Url = p.Url
                                                    }).AsNoTracking().FirstOrDefaultAsync();

                return produtoCarrinhoUsuario;
            }
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Produto.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
            }
        }

    }
}
