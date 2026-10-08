using System;

namespace ex_sistema_pagamento_loja.Entity
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; init; }
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }

    }
}