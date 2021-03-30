using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceProductApp : InterfaceGenericaApp<Produto>
    {
        Task AddProduct(Produto product);
        Task UpdateProduct(Produto product);
        Task<List<Produto>> ListarProdutosUsuario(string userId);

        Task<List<Produto>> ListarProdutosComEstoque();

        Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId);
        Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho);
    }
}
