using System.ComponentModel;
using ex_sistema_pagamento_loja.Entity;

List<Cliente> clientes = new();
List<Venda> vendas = new();
string opcao;
do
{
    Console.WriteLine(@"
    ================================
            SISTEMA DE VENDAS
    ================================
    1 - Cadastrar venda
    2 - Listar vendas
    3 - Realizar pagamento
    0 - Sair
    Digite o número da opção cadastrada:
    ================================");
    opcao = Console.ReadLine();
    switch(opcao)
    {
        case "1":
            CadastrarVenda(vendas, clientes);
            break;
        case "2":
            ListarVendas(vendas, clientes);
            break;
        case "3":
            RealizarPagamento(vendas, clientes);
            break;
        default:
            break;

    }
} while (opcao != "0");

static void CadastrarVenda(List<Venda> vendas, List<Cliente> clientes)
{
    Console.WriteLine("Digite o número da venda:");
    string numero = Console.ReadLine();
    if (vendas.Any(x=> x.Numero == numero))
    {
        Console.WriteLine("Esse número de venda já existe.");
        return;
    }
    Console.WriteLine("Digite o nome do cliente da venda:");
    string nome = Console.ReadLine();
    Console.WriteLine("Digite o CPF do cliente da venda:");
    string cpf = Console.ReadLine();
    Cliente cliente = null;
    try
    {
        cliente = new Cliente(nome, cpf);
        clientes.Add(cliente);
        Console.WriteLine("Cliente cadastrado com sucesso.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }
    Console.WriteLine("Digite o valor da compra:");
    if (! decimal.TryParse(Console.ReadLine(), out decimal valor))
    {
        Console.WriteLine("Digite um valor válido.");
        return;
    }
    try
    {
        Venda venda = new Venda(numero, cliente, valor);
        vendas.Add(venda);
        Console.WriteLine("Venda cadastrada com sucesso.");
        Console.WriteLine("Situação: Pendente.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
        return;
    }

}
static void ListarVendas(List<Venda> vendas, List<Cliente> clientes)
{
    for (int i =0; i < vendas.Count(); i++)
    {
        Console.WriteLine($"Venda: {vendas[i].Numero}");
        Console.WriteLine($"Cliente: {clientes[i].Nome}");
        Console.WriteLine($"Valor original:{vendas[i].Valor}");
        Console.WriteLine($"Situação:{vendas[i].Situacao}");
    }
}
static void RealizarPagamento (List<Venda> vendas, List<Cliente> clientes)
{
    Console.WriteLine("Informe o númeor da venda para pagamento:");
    string numero = Console.ReadLine();
    Venda venda = vendas.Find(x => x.Numero == numero);
    Console.WriteLine(@"
    Digite o número da forma de pagamento desejada:
    1 - PIX
    2 - Cartão de crédito
    3 - Dinheiro");
    string opcao = Console.ReadLine();
    if (venda == null)
        {
            Console.WriteLine("Número de venda não encontrado.");
            return;
        }
    Console.WriteLine($"Valor original: R${venda.Valor}");
    FormaPagamento formaPagamento;
    decimal valorFinal;
    switch (opcao)
    {
        case "1":   
            formaPagamento  = new PagamentoPIX();
            valorFinal = formaPagamento.CalcularValorFinal(venda);
            
            venda.RealizarPagamento(venda, valorFinal);
            break;
        case "2":
            formaPagamento  = new PagamentoCartao();
            valorFinal = formaPagamento.CalcularValorFinal(venda);
            Console.WriteLine($"Forma de pagamento: PIX");
            venda.RealizarPagamento(venda, valorFinal);
            break;
        case "3":
            formaPagamento  = new PagamentoDinheiro();
            valorFinal = formaPagamento.CalcularValorFinal(venda);
            Console.WriteLine($"Forma de pagamento: Dinheiro");
            venda.RealizarPagamento(venda, valorFinal);
            break;
        default:
            break;
    }
}