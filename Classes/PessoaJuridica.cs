using System.Text.RegularExpressions;
using CadastroClientesTroppo.Interfaces;

namespace CadastroClientesTroppo.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        // Atributos
        public string? cnpj { get; set; }

        public string? razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";


        // Métodos
        // (Método da superclasse Pessoa)
        public override float PagarImpostos(float rendimento)
        {
            if (rendimento <= 3000) 
            {
                return (rendimento / 100) * 3;
            }
            else if (rendimento > 3000 && rendimento <= 6000)
            {
                return (rendimento / 100) * 5;
            }
            else if (rendimento > 6000 && rendimento <= 10000)
            {
                return (rendimento / 100) * 7;
            }
            else
            {
                return (rendimento / 100) * 9;
            }
        }

        // (Método da interface IPessoaJuridica)
        // Formatos de cnpj: 
        // 1 - XX.XXX.XXX/0001-XX
        // 2 - XXXXXXXX0001XX
        public bool Validarcnpj(string cnpj)
        {
            // Regex.IsMatch retorna um booleano (true ou false)
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)"))
            {
                if (cnpj.Length == 18)
                {
                    if (cnpj.Substring(11, 4) == "0001")
                    {
                        return true;
                    }
                } else if (cnpj.Length == 14)
                {
                    if (cnpj.Substring(8, 4) == "0001")
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        public void inserir(PessoaJuridica pj) 
        {
            validarPastaArquivo(caminho);  // Usa método para verificar se já existe ou não a pasta e o arquivo

            // Ordem: nome, razao social, cnpj, rendimento, cep, rua, complemento, bairro, cidade, estado
            string[] pjStringArray = {$"{pj.nome},{pj.razaoSocial},{pj.cnpj},{pj.rendimento},{pj.endereco.cep},{pj.endereco.rua},{pj.endereco.complemento},{pj.endereco.bairro},{pj.endereco.cidade},{pj.endereco.estado}"};

            File.AppendAllLines(caminho, pjStringArray);

        }


        public List<PessoaJuridica> LerArquivo()
        {
            List<PessoaJuridica> listapj = new List<PessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaJuridica cadaPJ = new PessoaJuridica();
                Endereco cadaPJEnd = new Endereco();

                // Segue a ordem de atributos definida no método inserir():
                // Ordem: nome, razao social, cnpj, rendimento, cep, rua, complemento, bairro, cidade, estado
                cadaPJ.nome = atributos[0];
                cadaPJ.razaoSocial = atributos[1];
                cadaPJ.cnpj = atributos[2];
                cadaPJ.rendimento = float.Parse(atributos[3]);   // (O atributo 'rendimento' de PessoaJuridica precisa ser float)
                // Para colocar os valores do atributo da classe Endereco no obj cadaPJ, é preciso declarar um obj da classe Endereco
                // E jogar os atributos da classe Endereco nesse obj:
                cadaPJEnd.cep = atributos[4];
                cadaPJEnd.rua = atributos[5];
                cadaPJEnd.complemento = atributos[6];
                cadaPJEnd.bairro = atributos[7];
                cadaPJEnd.cidade = atributos[8];
                cadaPJEnd.estado = atributos[9];
                // Depois disso, atribuir ao obj cadaPJ:
                cadaPJ.endereco = cadaPJEnd;
                

                listapj.Add(cadaPJ);
            }

            return listapj;
        }


    }

    

}