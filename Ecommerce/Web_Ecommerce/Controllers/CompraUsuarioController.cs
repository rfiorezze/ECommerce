    using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Ecommerce.Controllers
{
    public class CompraUsuarioController : Controller
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly InterfaceCompraUsuarioApp _InterfaceCompraUsuarioApp;
        public readonly InterfaceProductApp _InterfaceProductApp;

        public CompraUsuarioController(UserManager<ApplicationUser> userManager, InterfaceCompraUsuarioApp InterfaceCompraUsuarioApp, InterfaceProductApp InterfaceProductApp)
        {
            _userManager = userManager;
            _InterfaceCompraUsuarioApp = InterfaceCompraUsuarioApp;
            _InterfaceProductApp = InterfaceProductApp;
        }

        [HttpPost("/api/AdicionarProdutoCarrinho")]
        public async Task<JsonResult> AdicionarProdutoCarrinho(string id, string nome, string qtd)
        {
            var usuario = await _userManager.GetUserAsync(User);

            int qtdCompra = Convert.ToInt32(qtd);

            var qtdEstoque = _InterfaceProductApp.GetEntityById(Convert.ToInt32(id)).Result.QtdEstoque;

            if (usuario != null)
            {
                if (qtdCompra <= qtdEstoque)
                {
                    await _InterfaceCompraUsuarioApp.AddProdutoCarrinho(usuario.Id, new CompraUsuario
                    {
                        IdProduto = Convert.ToInt32(id),
                        QtdCompra = Convert.ToInt32(qtd),
                        Estado = EstadoCompra.Produto_Carrinho,
                        UserId = usuario.Id
                    });
                    return Json(new { sucesso = true });
                }
                else
                    return Json(new { sucesso = false, mensagemErro = "Não temos esta quantidade em estoque!" });

            }

            return Json(new { sucesso = false, mensagemErro = "Favor efetuar o login antes de continuar!" });

        }
        [HttpGet("/api/QtdProdutosCarrinho")]
        public async Task<JsonResult> QtdProdutosCarrinho()
        {
            var usuario = await _userManager.GetUserAsync(User);            

            var qtd = 0;

            if (usuario != null)
            {
                qtd = await _InterfaceCompraUsuarioApp.QuantidadeProdutoCarrinhoUsuario(usuario.Id);

                return Json(new { sucesso = true, qtd = qtd });
            }

            return Json(new { sucesso = false, qtd = qtd });
        }

    }
}
