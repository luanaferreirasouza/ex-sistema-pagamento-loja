using System;

namespace ex_sistema_pagamento_loja.Entity
{
    public class PagamentoDinheiro : FormaPagamento
    {
        public override decimal CalcularValorFinal(Venda venda)
        {
            decimal valorFinalCredito = venda.Valor;
            return valorFinalCredito;
        }
    }
}