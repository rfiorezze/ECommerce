﻿using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppCompraUsuario : InterfaceCompraUsuarioApp
    {

        private readonly ICompraUsuario _ICompraUsuario;
        private readonly IServiceCompraUsuario _IServiceCompraUsuario;

        public AppCompraUsuario(ICompraUsuario ICompraUsuario, IServiceCompraUsuario IServiceCompraUsuario)
        {
            _ICompraUsuario = ICompraUsuario;
            _IServiceCompraUsuario = IServiceCompraUsuario;
        }

        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            return await _ICompraUsuario.QuantidadeProdutoCarrinhoUsuario(userId);
        }

        public async Task AddProdutoCarrinho(string userId, CompraUsuario compra)
        {
            await _IServiceCompraUsuario.AddProdutoCarrinho(userId, compra);
        }

        public async Task Add(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Add(Objeto);
        }

        public async Task Delete(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Delete(Objeto);
        }

        public async Task<CompraUsuario> GetEntityById(int Id)
        {
            return await _ICompraUsuario.GetEntityById(Id);
        }

        public async Task<List<CompraUsuario>> List()
        {
            return await _ICompraUsuario.List();
        }

        public async Task Update(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Update(Objeto);
        }

    }
}
