using System.Text;
using DesafioProjetoHospedagem.Models;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

Console.OutputEncoding = Encoding.UTF8;
//Mostrar Menu
Menu app = new Menu();
app.MostrarMenu();

//Se usuario for cadastrado seguir fluxo normal, se não retornar menu;


//Cadastro de Hospedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("\n========== Cadastrar Hospédes ==========");

Console.WriteLine("Digite a quantidade de hopédes");
int qtdHospedes =Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= qtdHospedes; i++)
{
    Console.WriteLine($"Digite o nome do hospéde {i}: ");
    string nomeHospede = Console.ReadLine();
    Pessoa hospede = new Pessoa(nome: nomeHospede);
    hospedes.Add(hospede);
}



Console.WriteLine("\n========== Escolha o tipo de Suíte ========== ");
Console.WriteLine("1. Suíte Tabelada (R$ 150,00)");
Console.WriteLine("2. Suíte Standard (R$ 330,00)");
Console.WriteLine("3. Suíte Premium (R$ 515,00)");
Console.WriteLine("\t 4. Sair");
Console.WriteLine("Digite a opção desejada:");
string opcao = Console.ReadLine();

Suite suite = new Suite();

switch(opcao)
{
    case "1":
        suite = new Suite(tipoSuite: "Tabelada", capacidade: qtdHospedes, valorDiaria: 150);
    break;
    case "2":
        suite = new Suite(tipoSuite: "Standard", capacidade: qtdHospedes, valorDiaria: 330);
        break;
    case "3":
        suite = new Suite(tipoSuite: "Premium", capacidade: qtdHospedes, valorDiaria: 515);
        break;
    case "4":
        Environment.Exit(0);
        break;
    default:
        Console.WriteLine("Opção inválida. Tente novamente.");
        app.MostrarMenu();
        break;
}

Console.WriteLine("Total de dias no hotel");
Reserva reserva = new Reserva();
reserva.DiasReservados = Convert.ToInt32(Console.ReadLine());

reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

bool executar = true;

while(executar)
{
    Console.WriteLine("\n============== Menu ==============");
    Console.WriteLine($"Número de hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Hóspedes: ");

    foreach (Pessoa hospede in reserva.Hospedes)
    {
        Console.WriteLine(hospede.Nome);
    }

    Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria()}");
    Console.WriteLine("\n==================================");
    Console.WriteLine("1. Exibir quantidade de hóspedes");
    Console.WriteLine("2. Exibir valor da diária");
    Console.WriteLine("3. Sair");
    Console.WriteLine("==================================");
    Console.Write("Digite a opção desejada: ");

    string opcao1 = Console.ReadLine();

    switch (opcao1)
    {
        case "1":
            Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
            break;
        case "2":
            Console.WriteLine($"Valor da diária: {reserva.CalcularValorDiaria()}");
            break;
        case "3":
            executar = false;
            break;
        default:
            Console.WriteLine("Opção inválida. Digite novamente.");
            break;
    }
}
Console.WriteLine("\nEncerrando o programa...");




































// Cria os modelos de hóspedes e cadastra na lista de hóspedes
/* List<Pessoa> hospedes = new List<Pessoa>();

Pessoa p1 = new Pessoa(nome: "Hóspede 1");
Pessoa p2 = new Pessoa(nome: "Hóspede 2");

hospedes.Add(p1);
hospedes.Add(p2);
*/

/* Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
*/