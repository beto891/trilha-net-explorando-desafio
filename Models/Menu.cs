using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;
using System.Diagnostics;

namespace DesafioProjetoHospedagem.Models
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public class Menu
    {
        public void MostrarMenu()
        {
            Console.WriteLine("============ Bem-vindo ao Sistema de Resevas do Hotel Premium ============");
            Console.WriteLine("1. Login como Usuário");
            Console.WriteLine("2. Registrar Usuário");
            Console.WriteLine("\t 5. Sair");

            int opcao = LerInteiro("Selecione uma opção: ");

            switch (opcao)
            {
                case 1:
                    LoginUsuario();
                    break;
                case 2:
                    RegistrarUsuario();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;        
                default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                MostrarMenu();
                break;
            }
        }

        //Menu Para Usuario
        public void MostrarMenuUsuario()
        {
            Console.WriteLine("============ Bem-vindo ao Sistema de Resevas do Hotel Premium ============");
        }

        //Métodos do menu;
        static int LerInteiro(string prompt)
        {
            while(true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int resultado))
                {
                    return resultado;
                }
                Console.WriteLine("Por favor, digite um número válido");
            }
        }

         // Método para ler uma senha do console sem exibir os caracteres digitados
        static string LerSenha()
        {
            string senha = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Se a tecla digitada não for Enter, adicionar ao texto da senha
                if (key.Key != ConsoleKey.Enter)
                {
                    senha += key.KeyChar;
                    Console.Write("*");
                }
            }
            // Continuar lendo as teclas até que Enter seja pressionado
            while (key.Key != ConsoleKey.Enter);

            return senha;
        }

         // Método para autenticar usuário
        public bool AutenticarUsuario(string usuario, string senha)
        {
            // Ler todas as linhas do arquivo de usuários cadastrados
            string[] linhas = File.ReadAllLines("Lista_Cadastro/DadosCadastrados.txt");

            // Verificar se as credenciais correspondem a algum usuário no arquivo
            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(';');
                if (partes[0] == usuario && partes[1] == senha)
                {
                    Console.WriteLine($"Bem vindo ao Hotel, {usuario}!");
                    return true; // Usuário e senha encontrados
                }
            }
            return false; // Usuário e senha não encontrados
        }

        public bool AutorizarUsuario(string usuario, string funcao)
        {
            string[] linha = File.ReadAllLines("Lista_Cadastro/DadosCadastrados.txt");

            foreach(string var in linha )
            {
                string[] partes = var.Split(';');
                if (partes[0] == usuario && partes[1] == funcao)
                {
                    return  true; //usuario autorizado com sucesso
                }
            }
            return false; //autorização falhou;
        }

        //Método de login Usuário;
        public void LoginUsuario()
        {
            Console.WriteLine("Digite seu nome de usuário: ");
            string usuario = (Console.ReadLine() ?.Trim()) ?? string.Empty;
            
            Console.WriteLine("Digite sua senha: ");
            string senha = LerSenha() ?.Trim() ?? string.Empty;

            AutenticarUsuario(usuario, senha);
            UsuarioRegistrado(usuario, senha);
            AutorizarUsuario(usuario, funcao: "");

            if (AutenticarUsuario(usuario, senha))
            {
                if (AutorizarUsuario(usuario, "Admin"))
                {
                    
                    Console.WriteLine("\nLogin bem-sucedido! Bem-vindo, administrador" + usuario + "!");
                     // Aqui você pode chamar o método para exibir as opções de administração
                    
                }
                else
                {
                    Console.WriteLine($"\nLogin bem-sucedido! Bem-vindo usuario {usuario}!");
                    
                }
            }

        }

        //Método para Registrar Usuario;
        public void RegistrarUsuario()
        {
            //cria uma instancia da classe Pessoa
            Pessoa pessoa = new Pessoa();

            //dados adiquiridos através do teclado
            Console.WriteLine("Digite seu nome: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine("Digite seu sobrenome:");
            pessoa.Sobrenome = Console.ReadLine();

            Console.WriteLine("Digite seu nome de usuário");
            pessoa.Usuario = Console.ReadLine();

            Console.WriteLine("Qual a sua função?");
            pessoa.Funcao = Console.ReadLine();

            Console.WriteLine("Digite uma senha");
            pessoa.Senha = Console.ReadLine();

            //StreamWrite método para guardar dados do teclado na lista

            using(StreamWriter sw = File.AppendText("Lista_Cadastro/DadosCadastrados.txt"))
            {
                sw.WriteLine($"Nome: " + pessoa.Nome  + ";" + "Sobrenome: " + pessoa.Sobrenome  + ";" + "Usuario: " + pessoa.Usuario  + ";" + "Função:" + pessoa.Funcao + ";"+ "Senha:" + pessoa.Senha);
            }
            Console.WriteLine("Registro concluído com Sucesso! Faça login para acessar o sistema.\n");
            MostrarMenu();
        }

        bool usuarioExiste = UsuarioRegistrado("usuario", "senha");

        //Método para verificar se usuário está registrado
        static bool UsuarioRegistrado(string usuario, string senha)
        {
            try 
            {
                string[] linhas = File.ReadAllLines("Lista_Cadastro/DadosCadastrados.txt");
                foreach(string linha in linhas)
                {
                    string[] divisor = linha.Split(";");
                    if (divisor[0] == usuario && divisor[0] == senha)
                    {

                        return true;
                    }
                } 
                Console.WriteLine($"\nLogin bem-sucedido!, Bem-vindo {usuario}\n");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verficar usuário\n {ex.Message}");
                return false;
            }
        }
        
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
