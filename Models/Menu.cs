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
            Console.WriteLine("\t 1. Login como Usuário");
            Console.WriteLine("\t 2. Login como Administrador");
            Console.WriteLine("\t 3. Registrar Usuário");
            Console.WriteLine("\t 4. Registrar Administrador");
            Console.WriteLine("\t 5. Sair");

            int opcao = LerInteiro("Selecione uma opção: ");

            switch (opcao)
            {
                case 1:
                    LoginUsuario();
                        break;
                case 2:
                    //LoginAdministrador();
                    break;
                case 3:
                    RegistrarUsuario();
                    break;
                case 4:
                    //RegistrarAdm();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;        
                default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                MostrarMenu();
                break;
            }

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
            string[] linhas = File.ReadAllLines("Lista_Cadastro/arquivoUsuarioESenha.txt");

            // Verificar se as credenciais correspondem a algum usuário no arquivo
            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(';');
                if (partes[0] == usuario && partes[1] == senha)
                {
                    Console.WriteLine($"Bem vindo ao Hotel Premium, {usuario}!");
                    return true; // Usuário e senha encontrados
                }
            }
            return false; // Usuário e senha não encontrados
        }

        //Método de login Usuário;
        public void LoginUsuario()
        {
            Console.WriteLine("\t Digite seu nome de usuário: ");
            string usuario = (Console.ReadLine() ?.Trim()) ?? string.Empty;
            

            Console.WriteLine("\t Digite sua senha: ");
            string senha = LerSenha();
            AutenticarUsuario(usuario, senha);

        }

        //Método para Registrar Usuario;
        public void RegistrarUsuario()
        {
            Console.WriteLine("\tDigite seu nome: ");
            string UserNome = Console.ReadLine();

            Console.WriteLine("\tDigite seu sobre nome:");
            string UserSobrenome = Console.ReadLine();

            Console.WriteLine("\tDigite seu nome de usuário");
            string usuario = Console.ReadLine();

            Console.WriteLine("\tDigite uma senha");
            string senha = Console.ReadLine();

            if (UsuarioRegistrado())
            {
                Console.WriteLine("Usuário existente.");
                MostrarMenu();
                return;
            }

            //StreamWrite método para guardar dados do teclado na lista

            using(StreamWriter sw = File.AppendText("Lista_Cadastro/arquivoUsuarioESenha.txt"))
            {
                sw.WriteLine(UserNome + ";" + UserSobrenome + ";" + usuario + ";" + senha);
            }
            Console.WriteLine("\nRegistro concluído com Sucesso! Faça login para acessar o sistema.");
            MostrarMenu(); 
        }

        //Método para verificar se usuário está registrado
        static bool UsuarioRegistrado()
        {
            string[] linhas = File.ReadAllLines("Lista_Cadastro/arquivoUsuarioESenha.txt");
            foreach(string var in linhas)
            {
                string[] divisor = var.Split(";");
                if (divisor[0] == var)
                {
                    return true;
                }
            } 
            return false;

    }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
