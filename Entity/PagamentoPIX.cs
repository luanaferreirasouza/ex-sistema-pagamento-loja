using System;

namespace ex_sistema_pagamento_loja.Entity
{
    public class PagamentoPIX : FormaPagamento
    {
        public override decimal CalcularValorFinal(Venda venda)
        {
            decimal valorFinalCredito = venda.Valor * 0.93m;
            return valorFinalCredito;
        }
    }
}