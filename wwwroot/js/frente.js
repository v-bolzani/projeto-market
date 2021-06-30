/* Declaração de variaveis */
var enderecoProduto = "https://localhost:5001/Produtos/Produto/";
var enderecoGerarVenda = "https://localhost:5001/Produtos/gerarvenda";
var produto;
var compra = [];
var __totalVenda__ = 0.0;

/* Inicio */
$("#posvenda".hide);

atualizarTotal();

/* Funções */
function atualizarTotal(){
    $("#totalVenda").html(__totalVenda__);
}

function preencherFormulario(dadosProduto){
    $("#campoNome").val(dadosProduto.nome);
    $("#campoCategoria").val(dadosProduto.categoria.nome);
    $("#campoFornecedor").val(dadosProduto.fornecedor.nome);
    $("#campoPreco").val(dadosProduto.precoVenda);
}

function zerarFormulario(){
    $("#campoNome").val("");
    $("#campoCategoria").val("");
    $("#campoFornecedor").val("");
    $("#campoPreco").val("");
    $("#campoQuantidade").val("");
}

function adicionarTabela(p,q){
    var produtoTemp = {};
    Object.assign(produtoTemp,produto);

    var venda = {produto: produtoTemp, quantidade: q, subtotal: produtoTemp.precoVenda * q}
    __totalVenda__ += venda.subtotal;
    atualizarTotal();
    compra.push(venda);

    $("#compras").append(`<tr>
       <td>${p.id}</td> 
       <td>${p.nome}</td> 
       <td>${q}</td> 
       <td>R$${p.precoVenda}</td> 
       <td>${p.medicao}</td> 
       <td>R$${p.precoVenda * q}</td> 
       <td><button class='btn btn-danger'>Remover</button></td> 
    </tr>`);
}

$("#produtoForm").on("submit", function(event){
    event.preventDefault();
    var produtoTabela = produto;
    var qtd = $("#campoQuantidade").val();
    adicionarTabela(produtoTabela, qtd);
    //var produto = undefined;
    zerarFormulario();
});

/* Ajax */
$("#pesquisar").click(function(){
    var codProduto = $("#codProduto").val();
    var enderecoTemporario = enderecoProduto + codProduto;
    $.post(enderecoTemporario, function(dados, status){
        produto = dados;

        var med = "";
        switch(produto.medicao){
            case 0:
                med = "Litro";
                break;
            case 1:
                med = "Quilo";
                break;
            case 2:
                med = "Unidade";
                break;
            default:
                med = "Não definido"
                break;      
        }
        produto.medicao = med;

        preencherFormulario(produto);
    }).fail(function(){
        alert("Produto inválido!");
    })
});

/* Finalizando a Venda */
$("#finalizarVendaBTN").click(function(){
    if(__totalVenda__ <= 0){
        alert("Compra inválida. Nenhum produto foi adicionado.");
        return;
    }

    var _valorPago = $("#valorPago").val();
    console.log(typeof _valorPago);
    if(!isNaN(_valorPago)){ // Not a Number
        _valorPago = parseFloat(_valorPago);
        if(_valorPago >= __totalVenda__){
            $("#posvenda").show();
            $("#prevenda").hide();
            $("#valorPago").prop("disable",true);

            var _troco = _valorPago - __totalVenda__;
            $("#troco").val(_troco);

            // Processar o array de compra
            compra.forEach(elemento => {
                elemento.produto = elemento.produto.id;
            });

            // Preparar um novo objeto
            var _venda = {total: __totalVenda__, troco: _troco, produtos: compra};

            // Enviar dados para o Back-end
            $.ajax({
                type: "POST",
                url: enderecoGerarVenda,
                dataType: "json",
                contentType: "application/json",
                data: JSON.stringify(_venda),
                success: function(data){
                    console.log("Dados enviados com sucesso.");
                    console.log(data);
                }
            });
        }else{
            alert("Valor pago é muito baixo.");
            return;
        }
    }else{
        alert("Valor inválido.");
        return;
    }
});

function restaurarModal(){
    $("#posvenda").hide();
    $("#prevenda").show();
    $("#valorPago").prop("disable",false);
    $("#troco").val("");
    $("#valorPago").val("");
}

$("#fecharModal").click(function(){
    restaurarModal();
});