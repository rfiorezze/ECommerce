var ObjetoVenda = new Object();


ObjetoVenda.AdicionarCarrinho = function (idProduto) {



    var nome = $("#nome_" + idProduto).val();
    var qtd = $("#qtd_" + idProduto).val();

    $.ajax({
        type: 'POST',
        url: "/api/AdicionarProdutoCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        data: {
            "id": idProduto, "nome": nome, "qtd": qtd
        },
        success: function (data) {
            if (data.sucesso) {
                ObjetoAlerta.AlertarTela(1, "Produto adicionado no carrinho!");
            }
            else {
                ObjetoAlerta.AlertarTela(2, data.mensagemErro);
            }
        }
    });


}

ObjetoVenda.CarregaProdutos = function () {
    $.ajax({
        type: 'GET',
        url: "/api/ListarProdutosComEstoque",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            var htmlConteudo = "";

            data.forEach(function (Entitie) {

                htmlConteudo += "<div class='col-xs-12 col-sm-4 col-md-4 col-lg-4'>";

                var idNome = "nome_" + Entitie.id;
                var idQtd = "qtd_" + Entitie.id;

                htmlConteudo += "<label id='" + idNome + "' > <strong>Produto:</strong> " + Entitie.nome + "</label></br>";                

                if (Entitie.url != null && Entitie.url != "" && Entitie.url != undefined) {
                    htmlConteudo += "<img width='200' height='200' src='" + Entitie.url + "'/></br>";
                }

                htmlConteudo += "<br/><label><strong> Valor: </strong>" + Entitie.valor + "</label></br>";

                htmlConteudo += "<strong>Quantidade : </strong><input type='number' style='width: 4em' value='1' id='" + idQtd + "'><br/>";

                htmlConteudo += "<input type='button' class='btn btn-primary'  onclick='ObjetoVenda.AdicionarCarrinho(" + Entitie.id + ")' value ='Comprar'> </br> ";

                htmlConteudo += " </div>";
            });

            $("#DivVenda").html(htmlConteudo);

        }
    });
}

ObjetoVenda.CarregaQtdCarrinho = function () {

    $("#qtdCarrinho").text("(0)");

    $.ajax({
        type: 'GET',
        url: "/api/QtdProdutosCarrinho",
        dataType: "JSON",
        cache: false,
        async: true,
        success: function (data) {

            if (data.sucesso) {
                $("#qtdCarrinho").text("(" + data.qtd + ")");
            }
        }
    });

    setTimeout(ObjetoVenda.CarregaQtdCarrinho, 5000);
}

$(function () {
    ObjetoVenda.CarregaProdutos();
    ObjetoVenda.CarregaQtdCarrinho();
});