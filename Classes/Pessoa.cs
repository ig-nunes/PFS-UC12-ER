using CadastroClientesTroppo.Interfaces;

namespace CadastroClientesTroppo.Classes

{
    public abstract class Pessoa : IPessoa
    {
        public string? nome { get; set; }

        public float rendimento { get; set; }

        // Composição com a classe Endereco
        public Endereco? endereco { get; set; }

        public abstract float PagarImpostos(float rendimento);


        // Método para verificar se existe a pasta e o arquivo .csv salvos. Caso não exista, eles são criados
        public void validarPastaArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];

            if (!Directory.Exists(pasta))   // Essa pasta não existe? (retorna true ou false)
            {
                Directory.CreateDirectory(pasta);  // Se ela não exite, crie a pasta
            }

            if (!File.Exists(caminho))  // Esse arquivo não existe? (retorna true ou false)
            {
                using (File.Create(caminho)){} // Se o arquivo não existe, crie o arquivo. O uso do 'using () {}' foi feito 
                                               // para, depois de criar o arquivo, o sistema poder fechá-lo
                
            }


        }
       
    }
}