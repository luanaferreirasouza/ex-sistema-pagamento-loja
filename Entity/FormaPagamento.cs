using System;

namespace ex_sistema_pagamento_loja.Entity
{
    public  abstract class FormaPagamento
    {
        public abstract decimal CalcularValorFinal(Venda venda);
    }
}