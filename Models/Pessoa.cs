namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa() { }

    private string _nome;
    private string _sobrenome;
    private string _senha;
    private string _usuario;
    public string Funcao;

    public Pessoa(string nome)
    {
        Nome = nome;
    }

    public Pessoa(string nome, string sobrenome, string senha, string usuario, string funcao)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        Senha = senha;
        Usuario = usuario;
        Funcao = funcao;
    }

    public string Nome
    { 
        get => _nome; 
        set
        {
            if (value == "")
            {
                throw new ArgumentException("O nome não pode ser vazio");
            }
            _nome = value;
        } 
        
    }
    public string Sobrenome 
    { 
        get => _sobrenome; 
        set 
        {
            if (value == "")
            {
                throw new ArgumentException ("O sobrenome não pode ser vazio");
            }
            _sobrenome = value;
        }
    }

    public string Usuario
    {
        get => _usuario;
        set 
        {
            if (value == "")
            {
                throw new ArgumentException("O usuario nçao pode ser vazio"); 
            }
            _usuario = value;
        }
    }

    public string Senha
    {
        get => _senha;
        set
        {
            if (value == "")
            {
                throw new ArgumentException("O campo de senha não pode ser vazio.");
            }
            _senha = value;
        }
    }

        public string funcao {get; set;} //'usuario' ou 'admin'
        
    public string NomeCompleto => $"{Nome} {Sobrenome}".ToUpper();
    
    public void Apresentar()
    {
        Console.WriteLine($"Olá {NomeCompleto}, Bem-vindo ao Hotel Premium");
    }
}