using CadastroClientesTroppo.Interfaces;

namespace CadastroClientesTroppo.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        //Atributos:
        public string? cpf { get; set; }

        public string? dataNasc { get; set; }

        public string caminho { get; private set; } = "Database/PessoaFisica.csv";


        // Métodos:
        // (Método da superclasse Pessoa)
        public override float PagarImpostos(float rendimento)
        {
            if (rendimento <= 1500) 
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 3500)
            {
                return (rendimento / 100) * 2;
            }
            else if (rendimento > 3500 && rendimento <= 6000)
            {
                return (rendimento / 100) * 3.5f;
            }
            else
            {
                return (rendimento / 100) * 5;
            }
        }

        // (Método da interface IPessoaFisica)
        public bool ValidarDataNasc(DateTime dataNasc)
        {
            DateTime dataAtual = DateTime.Today;

            double anos = (dataAtual - dataNasc).TotalDays / 365;

            // Console.WriteLine(anos);

            // Arredondamento de anos (sempre para baixo):
            int idade = (int)anos;

            // Console.WriteLine($"{idade}");

            if (anos >= 18 )
            {
                return true;
            }
            
            return false;
        }


        /// <summary>
        /// Método para validar se a pessoa tem mais de 18 anos. Recebe uma String como paramentro.
        /// </summary>
        /// <param name="dataNasc"></param>
        /// <returns></returns>
        public bool ValidarDataNasc(string dataNasc)
        {
            DateTime dataConvertida;

            if (DateTime.TryParse(dataNasc, out dataConvertida) == true)
            {
                DateTime dataAtual = DateTime.Today;

                double anos = (dataAtual - dataConvertida).TotalDays / 365;

                // Console.WriteLine(anos);

                // Arredondamento de anos (sempre para baixo):
                int idade = (int)anos;

                // Console.WriteLine($"{idade}");
                
                if (anos >= 18 )
                {
                    // Console.WriteLine para dizer se é maior de idade:
                    // Console.WriteLine("Idade maior ou igual a 18 anos");
                    return true;
                } 

                // Não foi necessário o 'else' abaixo por causa do 'return' no 'if' anterior, que 'terminaria' a função
                // Console.WriteLine para dizer se é maior de idade:
                // Console.WriteLine("Idade menor de 18 anos.");
                return false;

            }

            Console.WriteLine("Valor de dado de entrada inválido.");
            return false;
        }


        public void inserir(PessoaFisica pf)
        {
            validarPastaArquivo(caminho);  // Usa método para verificar se já existe ou não a pasta e o arquivo

            // Ordem: nome, cpf, data de nascimento, rendimento, cep, rua, complemento, bairro, cidade, estado
            string[] pfStringArray = {$"{pf.nome},{pf.cpf},{pf.dataNasc},{pf.rendimento},{pf.endereco.cep},{pf.endereco.rua},{pf.endereco.complemento},{pf.endereco.bairro},{pf.endereco.cidade},{pf.endereco.cidade}"};

            File.AppendAllLines(caminho, pfStringArray);
        }


        public List<PessoaFisica> LerArquivo()
        {
            List<PessoaFisica> listapf = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaFisica cadaPF = new PessoaFisica();
                Endereco cadaPFEnd = new Endereco();

                // Segue a ordem de atributos definida no método inserir():
                // Ordem: nome, cpf, data de nascimento, rendimento, cep, rua, complemento, bairro, cidade, estado
                cadaPF.nome = atributos[0];
                cadaPF.cpf = atributos[1];
                cadaPF.dataNasc = atributos[2];
                cadaPF.rendimento = float.Parse(atributos[3]); // (O atributo 'rendimento' de PessoaFisica precisa ser float)
                // Para colocar os valores do atributo da classe Endereco no obj cadaPF, é preciso declarar um obj da classe Endereco
                // E jogar os atributos da classe Endereco nesse obj:
                cadaPFEnd.cep = atributos[4];
                cadaPFEnd.rua = atributos[5];
                cadaPFEnd.complemento = atributos[6];
                cadaPFEnd.bairro = atributos[7];
                cadaPFEnd.cidade = atributos[8];
                cadaPFEnd.estado = atributos[9];
                // Depois disso, atribuir ao obj cadaPJ:
                cadaPF.endereco = cadaPFEnd;

                // Adicionar a lista
                listapf.Add(cadaPF);
            }

            return listapf;
        }
    }
}