using System;

namespace ex_sistema_pagamento_loja.Entity
{
    public class Venda
    {
        public string Numero { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Valor { get; private set; }
        public bool Status { get; private set; }
        public string Situacao => Status ? "Pago" : "Pendente";

        public Venda(string numero, Cliente cliente, decimal valor)
        {
            Numero = numero;
            Cliente = cliente;
            Valor = valor;
            Status = false;
            ValidacaoDados(numero, cliente, valor);
        }
        public void ValidacaoDados(string numero, Cliente cliente, decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O Valor da venda deve ser maior que 0.");
            }
            if (string.IsNullOrWhiteSpace(Numero))
            {
                throw new ArgumentException("O número da venda deve ser informado.");
            }
        }
        static void CriarVenda (String numero, Cliente cliente, decimal valor, List<Venda> vendas)
        {
            try
            {
                Venda venda = new Venda(numero, cliente, valor);
                vendas.Add(venda);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RealizarPagamento(Venda venda, decimal valorFinal)
        {
            if (venda.Status == true)
            {
                Console.WriteLine("Essa venda já foi paga.");
                Console.WriteLine($"Valor final: R${valorFinal}");
                return;
            }
            else
            {
                Console.WriteLine($"Valor final: R${valorFinal}");
                Console.WriteLine($"Situação: Pago");
                venda.Status = true;
            }
            
        }

    }

}