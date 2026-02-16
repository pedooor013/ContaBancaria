namespace ContaBancaria;

public class ContaBancaria
{
    public string NumeroConta { get; private set; }
    private decimal _saldo;
    public string NomeTitular { get; private set; }

    public void RealizarDeposito(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("Valor inválido para deposíto!");
            return;
        }

        _saldo += valor;
    }

    public void RealizarSaque(decimal valor)
    {
        if (valor > _saldo)
        {
            Console.WriteLine("Saldo insuficiente!");
            return;
        }else if (valor <= 0)
        {
            Console.WriteLine("Valor de saque inválido!");
            return;
        }
        
        _saldo -= valor;
    }

    public decimal ExibirSaldo()
    {
        return _saldo;
    }
    
    //Construtor
    public ContaBancaria(string numeroConta, string nomeTitular)
    {
        if (string.IsNullOrWhiteSpace(numeroConta))
            throw new ArgumentException("Número da conta inválido.");

        if (string.IsNullOrWhiteSpace(nomeTitular))
            throw new ArgumentException("Nome do titular inválido.");
        
        NumeroConta = numeroConta;
        NomeTitular = nomeTitular;
    }
}