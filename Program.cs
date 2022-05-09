// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using CadastroClientesTroppo.Classes;

Console.Clear();
Console.WriteLine(@$"
=============================================
|    Bem-vindo ao sistema de cadastro de    |
|        Pessoas físicas e Juridicas        |
=============================================
");


BarraCarregamento("Carregando", 500);

List<PessoaFisica> listapf = new List<PessoaFisica>();
List<PessoaJuridica> listapj = new List<PessoaJuridica>();


string? opcao;

do
{
    Console.Clear();
    Console.WriteLine(@$"
=============================================
|           Escolha uma opção:              |
|-------------------------------------------|
|       1 - Acessar Pessoa Física           |
|       2 - Acessar Pessoa Jurídica         |
|                                           |
|       0 - Sair do Sistema                 |
=============================================
");


    opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":

            PessoaFisica metodospf = new PessoaFisica();
            PessoaFisica pf = new PessoaFisica();
            Endereco novoendereco = new Endereco();
            string? opcaoPF;

            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=============================================
|           Escolha uma opção:              |
|-------------------------------------------|
|        1 - Cadastrar Pessoa Física        |
|        2 - Listar Pessoa Física           |
|                                           |
|        0 - Voltar Menu Anterior           |
=============================================
");

                opcaoPF = Console.ReadLine();

                switch (opcaoPF)
                {
                    case "1":




                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastrar");
                        pf.nome = Console.ReadLine();

                        Console.WriteLine($"Digite o número do CPF");
                        pf.cpf = Console.ReadLine();

                        bool dataValida;
                        do
                        {
                            Console.WriteLine($"Digite a data de nascimento. Ex.: DD/MM/AAAA");
                            string? dataNasc = Console.ReadLine();

                            dataValida = metodospf.ValidarDataNasc(dataNasc);

                            if (dataValida)
                            {
                                pf.dataNasc = dataNasc;
                            }
                            else
                            {
                                Console.WriteLine($"Data inválida. Por favor, digite uma data novamente.");
                            }

                        } while (dataValida == false);  // Poderia ser também !davaValida, que é igual a dataValida == false

                        Console.WriteLine($"Digite o rendimento mensal (digite somente números)");
                        pf.rendimento = float.Parse(Console.ReadLine());


                        Console.WriteLine($"Digite o CEP da rua");
                        novoendereco.cep = Console.ReadLine();

                        Console.WriteLine($"Digite o nome da rua");
                        novoendereco.rua = Console.ReadLine();

                        Console.WriteLine($"Digite o complemento (aperte ENTER caso não haja complemento)");
                        novoendereco.complemento = Console.ReadLine();

                        Console.WriteLine($"Digite o bairro");
                        novoendereco.bairro = Console.ReadLine();

                        Console.WriteLine($"Digite a cidade");
                        novoendereco.cidade = Console.ReadLine();

                        Console.WriteLine($"Digite o Estado");
                        novoendereco.estado = Console.ReadLine();

                        string? endCom;
                        do
                        {
                            Console.WriteLine($"Este endereço é comercial? S/N");
                            endCom = Console.ReadLine().ToUpper();
                            if (endCom == "S")
                            {
                                novoendereco.comercial = true;

                            }
                            else if (endCom == "N")
                            {
                                novoendereco.comercial = false;
                            }
                            else
                            {
                                Console.WriteLine($"Resposta inválida!");

                            }


                        } while (endCom != "S" && endCom != "N");

                        pf.endereco = novoendereco;

                        // Atividade Adicionar em uma lista
                        listapf.Add(pf);


                        // Atividade escrever um arquivo .txt
                        // Salvar os dados da pessoa cadastrada em um arquivo .txt:
                        //                         StreamWriter sw = new StreamWriter($"{pf.nome}.txt");
                        //                         sw.WriteLine(@$"
                        // - Nome: {pf.nome}
                        // - CPF: {pf.cpf}
                        // - Data de Nascimento: {pf.dataNasc}
                        // - Maior de Idade: {(metodospf.ValidarDataNasc(pf.dataNasc) ? "Sim" : "Não")}
                        // - Rendimento: {pf.rendimento.ToString("C")}  
                        // - Taxa a ser paga como imposto: {pf.PagarImpostos(pf.rendimento).ToString("C")}
                        // - Endereço:
                        //     CEP: {pf.endereco.cep}
                        //     Rua: {pf.endereco.rua}
                        //     Complemento: {pf.endereco.complemento}
                        //     Bairro: {pf.endereco.bairro}
                        //     Cidade: {pf.endereco.cidade}
                        //     Estado: {pf.endereco.estado}
                        //     Endereço é comercial? {(pf.endereco.comercial ? "Sim" : "Não")}
                        //                         ");
                        //                         sw.Close();



                        // Outra forma de salvar os dados da pessoa cadastrada em um arquivo .txt (usando using 
                        // que é diferente de using System).
                        // Nesse caso, não é preciso usar o close():
                        using (StreamWriter sw = new StreamWriter($"{pf.nome}.txt"))
                        {
                            sw.WriteLine(@$"
- Nome: {pf.nome}
- CPF: {pf.cpf}
- Data de Nascimento: {pf.dataNasc}
- Maior de Idade: {(metodospf.ValidarDataNasc(pf.dataNasc) ? "Sim" : "Não")}
- Rendimento: {pf.rendimento.ToString("C")}  
- Taxa a ser paga como imposto: {pf.PagarImpostos(pf.rendimento).ToString("C")}
- Endereço:
    CEP: {pf.endereco.cep}
    Rua: {pf.endereco.rua}
    Complemento: {pf.endereco.complemento}
    Bairro: {pf.endereco.bairro}
    Cidade: {pf.endereco.cidade}
    Estado: {pf.endereco.estado}
    Endereço é comercial? {(pf.endereco.comercial ? "Sim" : "Não")}
                        ");
                        }



                        // Método para inserir a pessoa cadastrada em um arquivo .csv com todos os cadastros
                        metodospf.inserir(pf);


                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Thread.Sleep(4000);

                        break;


                    case "2":
                        // Atividade ler as pessoas cadastradas a partir da lista criada (não salvo quando reinicia programa)
                        //                         if (listapf.Count > 0)
                        //                         {
                        //                             foreach (PessoaFisica cadaPessoa in listapf)
                        //                             {
                        //                                 Console.Clear();
                        //                                 Console.WriteLine(@$"
                        // - Nome: {cadaPessoa.nome}
                        // - CPF: {cadaPessoa.cpf}
                        // - Data de Nascimento: {cadaPessoa.dataNasc}
                        // - Maior de Idade: {(metodospf.ValidarDataNasc(cadaPessoa.dataNasc) ? "Sim" : "Não")}
                        // - Rendimento: {cadaPessoa.rendimento.ToString("C")}  
                        // - Taxa a ser paga como imposto: {cadaPessoa.PagarImpostos(cadaPessoa.rendimento).ToString("C")}
                        // - Endereço:
                        //     CEP: {cadaPessoa.endereco.cep}
                        //     Rua: {cadaPessoa.endereco.rua}
                        //     Complemento: {cadaPessoa.endereco.complemento}
                        //     Bairro: {cadaPessoa.endereco.bairro}
                        //     Cidade: {cadaPessoa.endereco.cidade}
                        //     Estado: {cadaPessoa.endereco.estado}
                        //     Endereço é comercial? {(pf.endereco.comercial ? "Sim" : "Não")}                        

                        // ");

                        //                                 Thread.Sleep(1000);
                        //                             }

                        //                             Console.WriteLine($"Aperte 'ENTER' para continuar");
                        //                             Console.ReadLine();

                        //                         }
                        //                         else
                        //                         {
                        //                             Console.WriteLine($"Lista vazia!");
                        //                             Console.WriteLine($"Retornando para o menu anterior...");
                        //                             Thread.Sleep(4000);
                        //                         }



                        // Atividade Ler arquivo .txt
                        // Caso usasse arquivo .txt salvo para ler dados de uma pessoa cadastrada:
                        // (de novo, sem a necessidade de terminar usando o close(), devido ao uso do 'using')

                        // using (StreamReader sr = new StreamReader("igor.txt"))
                        // {

                        //     string? linha;
                        //     while ((linha = sr.ReadLine()) != null)
                        //     {
                        //         Console.WriteLine($"{linha}");

                        //     }

                        // }



                        // Leitura de cada pessoa cadastrada no arquivo .csv

                        List<PessoaFisica> listaPessoaFisica = metodospf.LerArquivo();

                        foreach (PessoaFisica cadaPF in listaPessoaFisica)
                        {
                            Console.WriteLine(@$"
                            - Nome: {cadaPF.nome}
                            - CPF: {cadaPF.cpf}
                            - Data de Nascimento: {cadaPF.dataNasc}
                            - Rendimento: {cadaPF.rendimento}
                            - Endereço:
                                CEP: {cadaPF.endereco.cep}
                                Rua: {cadaPF.endereco.rua}
                                Complemento: {cadaPF.endereco.complemento}
                                Bairro: {cadaPF.endereco.bairro}
                                Cidade: {cadaPF.endereco.cidade}
                                Estado: {cadaPF.endereco.estado}

                            ");

                            Console.WriteLine($"Aperte 'ENTER' para continuar");
                            Console.ReadLine();

                        }


                        break;

                    case "0":
                        // Case de voltar ao menu anterior
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digitar umas das opções disponíveis:");

                        Thread.Sleep(3000);
                        break;

                }



            } while (opcaoPF != "0");


            // Pessoa física e método ValidarDataNasc()

            // PessoaFisica pf = new PessoaFisica();
            // PessoaFisica metodospf = new PessoaFisica();
            // Endereco novoendereco = new Endereco();


            // novoendereco.cep = "0123456789";
            // novoendereco.rua = "Rua do exemplo";
            // novoendereco.complemento = "16B";
            // novoendereco.bairro = "Barra";
            // novoendereco.cidade = "Rio de Janeiro";
            // novoendereco.estado = "RJ";
            // novoendereco.comercial = false;

            // pf.nome = "Exemplo";
            // pf.rendimento = 5000.5f;
            // pf.cpf = "1234567890";
            // pf.dataNasc = new DateTime(2000, 1, 1);
            // pf.endereco = novoendereco;


            // Console.Clear();
            // Console.WriteLine(@$"
            // - Nome: {pf.nome}
            // - CPF: {pf.cpf}
            // - Data de Nascimento: {pf.dataNasc}
            // - Maior de Idade: {(metodospf.ValidarDataNasc(pf.dataNasc) ? "Sim" : "Não")}
            // - Rendimento: {pf.rendimento.ToString("C")}  
            // - Taxa a ser paga como imposto: {pf.PagarImpostos(pf.rendimento).ToString("C")}
            // - Endereço:
            //     CEP: {pf.endereco.cep}
            //     Rua: {pf.endereco.rua}
            //     Complemento: {pf.endereco.complemento}
            //     Bairro: {pf.endereco.bairro}
            //     Cidade: {pf.endereco.cidade}
            //     Estado: {pf.endereco.estado}
            // ");



            // Obs.: metodo.ToString("C") retorna número no formato monetário brasileiro (Exemplo: R$ 1.000,00)
            // Obs. 2: Método abaixo para averiguar se é maior de idade foi passado para o Console.WriteLine anterior
            //      Console.WriteLine($"{metodospf.ValidarDataNasc(pf.dataNasc)}");
            // Exemplo de estrutura de um 'if ternário': 
            //      (metodospf.ValidarDataNasc(pf.dataNasc)? "Sim" : "Não");   Equivalente a:
            //      if (metodospf.ValidarDataNasc(pf.dataNasc){
            //          Console.WriteLine("Sim")
            //      })else {
            //          Console.WriteLine("Não")
            //      }


            // Console.WriteLine($"Aperte 'ENTER' para continuar");
            // Console.ReadLine();

            // ValidarDataNasc com paramentro DateTime
            // pf.ValidarDataNasc(new DateTime(2000, 1, 1));

            // pf.ValidarDataNasc("01/01/1990");

            break;

        case "2":


            PessoaJuridica pj = new PessoaJuridica();
            PessoaJuridica metodospj = new PessoaJuridica();
            Endereco endereco = new Endereco();
            string? opcaoPJ;


            do
            {
                Console.Clear();
                Console.WriteLine(@$"
=============================================
|           Escolha uma opção:              |
|-------------------------------------------|
|        1 - Cadastrar Pessoa Jurídica      |
|        2 - Listar Pessoa Jurídica         |
|                                           |
|        0 - Voltar Menu Anterior           |
=============================================
");

                opcaoPJ = Console.ReadLine();

                switch (opcaoPJ)
                {
                    case "1":





                        Console.WriteLine($"Digite o nome da pessoa fisica que deseja cadastrar");
                        pj.nome = Console.ReadLine();

                        Console.WriteLine($"Digite a razao social");
                        pj.razaoSocial = Console.ReadLine();






                        // Console.WriteLine($"Digite o CNPJ (no formato 'xx.xxx.xxx/xxxx-xx')");
                        // pj.cnpj = "00.000.000/0001-00";

                        bool cnpjValido;

                        do
                        {
                            Console.WriteLine($"Digite o CNPJ (no formato 'xx.xxx.xxx/0001-xx' ou 'xxxxxxxx0001xx')");
                            string? cnpj = Console.ReadLine();

                            cnpjValido = metodospj.Validarcnpj(cnpj);

                            if (cnpjValido)
                            {
                                pj.cnpj = cnpj;
                            }
                            else
                            {
                                Console.WriteLine($"CNPJ inválido.");
                            }

                        } while (cnpjValido == false);

                        Console.WriteLine($"Digite o rendimento");
                        pj.rendimento = float.Parse(Console.ReadLine());



                        Console.WriteLine($"Digite o cep");
                        endereco.cep = Console.ReadLine();

                        Console.WriteLine($"Digite a rua");
                        endereco.rua = Console.ReadLine();

                        Console.WriteLine($"Digite o complemento (Aperte ENTER caso não haja comlemento)");
                        endereco.complemento = Console.ReadLine();

                        Console.WriteLine($"Digite o bairro");
                        endereco.bairro = Console.ReadLine();

                        Console.WriteLine($"Digite a cidade");
                        endereco.cidade = Console.ReadLine();

                        Console.WriteLine($"Digite o estado");
                        endereco.estado = Console.ReadLine();


                        string? endCom;
                        do
                        {
                            Console.WriteLine($"Este endereço é comercial? S/N");
                            endCom = Console.ReadLine().ToUpper();
                            if (endCom == "S")
                            {
                                endereco.comercial = true;

                            }
                            else if (endCom == "N")
                            {
                                endereco.comercial = false;
                            }
                            else
                            {
                                Console.WriteLine($"Resposta inválida!");

                            }


                        } while (endCom != "S" && endCom != "N");

                        pj.endereco = endereco;
                        metodospj.endereco = endereco;


                        // Atividade Adicionar em uma lista
                        listapj.Add(pj);




                        // Atividade escrever um arquivo .txt
                        // Salvar os dados da pessoa cadastrada em um arquivo .txt:
                        StreamWriter sw = new StreamWriter($"{pj.nome}.txt");
                        sw.WriteLine(@$"
- Nome: {pj.nome}
- CNPJ: {pj.cnpj}
- Razão Social: {pj.razaoSocial}
- Rendimento: {pj.rendimento.ToString("C")}
- Endereço:
    CEP: {pj.endereco.cep}
    Rua: {pj.endereco.rua}
    Complemento: {pj.endereco.complemento}
    Bairro: {pj.endereco.bairro}
    Cidade: {pj.endereco.cidade}
    Estado: {pj.endereco.estado}
                        ");
                        sw.Close();

                        // Outra forma de salvar os dados da pessoa cadastrada em um arquivo .txt (usando using que é
                        // diferente de using System).
                        // Nesse caso, não é preciso usar o close():







                        // Método para inserir a pessoa cadastrada em um arquivo .csv com todos os cadastros
                        metodospj.inserir(pj);


                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Thread.Sleep(4000);


                        break;


                    case "2":

                        // Atividade ler as pessoas cadastradas a partir da lista criada (não salvo quando reinicia programa)
                        //                         if (listapj.Count > 0)
                        //                         {

                        //                             foreach (PessoaJuridica cadaPessoaJ in listapj)
                        //                             {

                        //                                 Console.Clear();
                        //                                 Console.WriteLine(@$"
                        // - Nome: {cadaPessoaJ.nome}
                        // - CNPJ: {cadaPessoaJ.cnpj}
                        // - CNPJ válido: {(metodospj.Validarcnpj(cadaPessoaJ.cnpj) ? "Sim" : "Não")}
                        // - Razão Social: {cadaPessoaJ.razaoSocial}
                        // - Rendimento: {cadaPessoaJ.rendimento.ToString("C")}
                        // - Taxa a ser paga como imposto: {cadaPessoaJ.PagarImpostos(cadaPessoaJ.rendimento).ToString("C")}
                        // - Endereço:
                        //     CEP: {cadaPessoaJ.endereco.cep}
                        //     Rua: {cadaPessoaJ.endereco.rua}
                        //     Complemento: {cadaPessoaJ.endereco.complemento}
                        //     Bairro: {cadaPessoaJ.endereco.bairro}
                        //     Cidade: {cadaPessoaJ.endereco.cidade}
                        //     Estado: {cadaPessoaJ.endereco.estado}
                        //     Endereço é comercial? {(metodospj.endereco.comercial ? "Sim" : "Não")}
                        // ");


                        //                                 Console.WriteLine($"Aperte 'ENTER' para continuar");
                        //                                 Console.ReadLine();


                        //                             }


                        //                         }
                        //                         else
                        //                         {
                        //                             Console.WriteLine($"Lista vazia!");
                        //                             Console.WriteLine($"Retornando para o menu anterior...");
                        //                             Thread.Sleep(4000);
                        //                         }





                        // Atividade Ler arquivo .txt
                        // Caso usasse arquivo .txt salvo para ler dados de uma pessoa cadastrada:
                        // (de novo, sem a necessidade de terminar usando o close(), devido ao uso do 'using')

                        // Obs.: é necessário cadastrar uma pessoa juridica com o nome GameMania, para que haja a criação de um
                        // arquivo com o nome "GameMania.txt". É necessário também observar se a 'Atividade escrever em um arquivo
                        // .txt' está comentada ou não, caso esteja, é necessário descomentar.
                        // using (StreamReader sr = new StreamReader("GameMania.txt"))
                        // {

                        //     string? linha;
                        //     while ((linha = sr.ReadLine()) != null)
                        //     {
                        //         Console.WriteLine($"{linha}");

                        //     }

                        // }






                        // Leitura de cada pessoa cadastrada no arquivo .csv
                        List<PessoaJuridica> listaPessoaJuridica = metodospj.LerArquivo();

                        foreach (PessoaJuridica cadaPJ in listaPessoaJuridica)
                        {

                            Console.WriteLine(@$"
- Nome: {cadaPJ.nome}
- CNPJ: {cadaPJ.cnpj}
- Razão Social: {cadaPJ.razaoSocial}
- Rendimento: {cadaPJ.rendimento.ToString("C")}
- Endereço:
    CEP: {cadaPJ.endereco.cep}
    Rua: {cadaPJ.endereco.rua}
    Complemento: {cadaPJ.endereco.complemento}
    Bairro: {cadaPJ.endereco.bairro}
    Cidade: {cadaPJ.endereco.cidade}
    Estado: {cadaPJ.endereco.estado}
");

                            Console.WriteLine($"Aperte 'ENTER' para continuar");
                            Console.ReadLine();

                        }



                        break;

                    case "0":
                        // case voltar para o menu anterior
                        break;

                    default:

                        Console.Clear();
                        Console.WriteLine($"Opção inválida, por favor digitar umas das opções disponíveis:");

                        Thread.Sleep(3000);

                        break;

                }





            } while (opcaoPJ != "0");


            // Atividade declarar uma pessoa juridica e imprimir no console seus dados
            // Pessoa juridica e método Validarcnpj()

            // PessoaJuridica pj = new PessoaJuridica();
            // PessoaJuridica metodospj = new PessoaJuridica();
            // Endereco endereco = new Endereco();


            // endereco.cep = "1234567890";
            // endereco.rua = "Rua Gamer";
            // endereco.complemento = "10A";
            // endereco.bairro = "Catete";
            // endereco.cidade = "São Paulo";
            // endereco.estado = "SP";
            // endereco.comercial = true;

            // pj.nome = "Game Mania";
            // pj.rendimento = 1000000.5f;
            // pj.razaoSocial = "Game Mania LTDA";
            // pj.cnpj = "00.000.000/0001-00";
            // pj.endereco = endereco;


            // Console.Clear();
            // Console.WriteLine(@$"
            // - Nome: {pj.nome}
            // - CNPJ: {pj.cnpj}
            // - CNPJ válido: {(pj.Validarcnpj(pj.cnpj) ? "Sim" : "Não")}
            // - Razão Social: {pj.razaoSocial}
            // - Rendimento: {pj.rendimento.ToString("C")}
            // - Taxa a ser paga como imposto: {pj.PagarImpostos(pj.rendimento).ToString("C")}
            // - Endereço:
            //     CEP: {pj.endereco.cep}
            //     Rua: {pj.endereco.rua}
            //     Complemento: {pj.endereco.complemento}
            //     Bairro: {pj.endereco.bairro}
            //     Cidade: {pj.endereco.cidade}
            //     Estado: {pj.endereco.estado}
            // ");

            // // Console.WriteLine(metodospj.Validarcnpj(pj.cnpj));


            // Console.WriteLine($"Aperte 'ENTER' para continuar");
            // Console.ReadLine();


            break;

        case "0":
            Console.WriteLine($"Obrigado por utilizar nosso sistema!");

            BarraCarregamento("Finalizando", 500);

            break;

        default:
            Console.Clear();
            Console.WriteLine($"Opção inválida, por favor digitar umas das opções disponíveis:");

            Thread.Sleep(3000);

            break;

    }
} while (opcao != "0");



static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.Yellow;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.Write(texto);

    for (int i = 0; i < 8; i++)
    {
        Console.Write(".");
        Thread.Sleep(tempo);
    }

    Console.ResetColor();
}
