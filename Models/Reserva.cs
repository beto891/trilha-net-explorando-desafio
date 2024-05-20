namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            
            {
                if (hospedes.Count <= Suite.Capacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    // TODO: Retornar uma exception caso a capacidade seja menor que o número de hóspedes recebido
                    // *IMPLEMENTE AQUI*
                    throw new ArgumentException("Capacidade excedida. Não é possível cadastrar mais hospédes do que a capacidade da suíte.");
                }
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // TODO: Retorna a quantidade de hóspedes (propriedade Hospedes)
            // *IMPLEMENTE AQUI*

            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // TODO: Retorna o valor da diária
            // Cálculo: DiasReservados X Suite.ValorDiaria
            // *IMPLEMENTE AQUI*
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 5 && DiasReservados <= 10)
            {
                valor -= valor * 0.1m;
            }
            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            // *IMPLEMENTE AQUI*
            else if (true)
            {
                valor -= valor * 0.12m;
            }

            return valor;
        }
    }
}