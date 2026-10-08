using System;

namespace ex_sistema_pagamento_loja.Entity
{
    public class PagamentoCartao : FormaPagamento
    {   
        public override decimal CalcularValorFinal(Venda venda)
        {
            decimal valorFinalCredito = venda.Valor * 1.03m;
            return valorFinalCredito;
        }
    }
}