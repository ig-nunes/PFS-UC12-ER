namespace CadastroClientesTroppo.Interfaces
{
    public interface IPessoaFisica
    {
        bool ValidarDataNasc(DateTime dataNasc);
        
        bool ValidarDataNasc(string dataNasc);
    }
}