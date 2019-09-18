using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean Continua = true;
            List<SingnUser> listaPessoas = new List<SingnUser>();

            do
            {
                int qtdPessoas = 0;
                for(int i = 0; i < listaPessoas.Count; i++)
                {
                    qtdPessoas++;
                }
                Console.WriteLine("Menu de Cadastro \n");
                Console.WriteLine($"Quantidade de cadastros já feitos: {qtdPessoas}");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Alterar");
                Console.WriteLine("3 - Excluir");
                Console.WriteLine("4 - Listar");
                Console.WriteLine("5 - Pesquisar");
                Console.WriteLine("00 - Sair\n");
                Console.WriteLine("Digite sua opção: ");
                String opc = Console.ReadLine();
                Console.Clear();

                switch (opc)
                {
                    case "1":
                        Console.WriteLine("\nInserir\n");
                        listaPessoas.Add(IncluirPessoa());
                        Console.WriteLine("----------------------------------------------------------------------------------------------------------\n");

                        break;
                    case "2":
                        Console.WriteLine("\nAlterar\n");

                        Console.WriteLine("Digite o Nome do usuário à ser alterado");
                        string usuario = (Console.ReadLine());
                        usuario = usuario.ToUpper();
                        SingnUser Config = listaPessoas.Find(x => x.Nome == usuario);
                        //----------------------------------------------------
                        Console.Write("Nome:");
                        Config.Nome = Console.ReadLine();
                        Config.Nome = Config.Nome.ToUpper();
                        //----------------------------------------------------
                        bool sexoConfig = true;
                        do
                        {
                            Console.Write("Sexo: (M) - (F)");
                            Config.Sexo = Console.ReadLine();
                            Config.Sexo = Config.Sexo.ToUpper();
                            if (Config.Sexo == "M" || Config.Sexo == "F")
                            {
                                sexoConfig = false;
                            }
                            else
                            {
                                Console.WriteLine("*** Insira um valor aceito M - F ***");
                                sexoConfig = true;
                            }
                        }
                        while (sexoConfig);
                        //----------------------------------------------------
                        bool idadeConfig = true;
                        do
                        {
                            Console.Write("Idade:");
                            Config.Idade = Int32.Parse(Console.ReadLine());
                            if (Config.Idade > 100 && Config.Idade <= 120)
                            {
                                Console.WriteLine("***Tem certeza que está é a sua idade?*** \n   (S) - (N)");
                                string conf = Console.ReadLine();
                                conf = conf.ToUpper();
                                if (conf == "S")
                                {
                                    idadeConfig = false;
                                }
                                else if (conf == "N")
                                {
                                    idadeConfig = true;
                                }
                            }
                            else if (Config.Idade > 120)
                            {
                                Console.WriteLine("***Tá de brincadeira né!? Digite uma idade válida!***");
                                idadeConfig = true;
                            }
                            else
                            {
                                idadeConfig = false;
                            }

                            Console.Write("Email:");
                            Config.Email = Console.ReadLine();

                            Console.WriteLine("Quantos irmãos você possui: ");
                            Config.qtdIrmaos = float.Parse(Console.ReadLine());
                        }
                        while (idadeConfig);
                        break;
                    case "3":
                        Console.WriteLine("\n Excluir \n");
                        for (int i = 1; i < listaPessoas.Count; i++)
                        {
                            foreach (SingnUser pessoa in listaPessoas)
                            {
                                Console.WriteLine($"{i++} {pessoa.Nome}");
                            }
                        }
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------\n");
                        Console.WriteLine("Digite o ID do Usuário à ser excuido\n (posição do usuário na lista)");
                        int userDel = Int32.Parse(Console.ReadLine());
                        userDel--;

                        Console.WriteLine("Deseja realmente excluir esse cadastro?\n  (S) - (N)");
                        string excluir = Console.ReadLine();
                        excluir = excluir.ToUpper();
                        
                        if (excluir == "S")
                        {
                            if (userDel <= listaPessoas.Count)
                            {
                                listaPessoas.RemoveAt(userDel);
                            }
                            else
                            {
                                Console.WriteLine("Usuário não encontrado na lista.");
                            }
                        }
                        Console.Clear();

                        break;
                    case "4":
                        Console.WriteLine("\n Listar\n");
                        if(listaPessoas.Count == 0)
                        {
                            Console.WriteLine("Você não possui nemnhum cadastro.\n");
                        }
                        Console.WriteLine(" Nome     Sexo     Idade      ");

                        for(int i = 0; i< listaPessoas.Count; i++)
                        {
                            foreach (SingnUser pessoa in listaPessoas)
                            {
                                Console.WriteLine($"{i++} {pessoa.Nome}   -   {pessoa.Sexo}   -   {pessoa.Idade}");
                            }
                        }
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------\n");
                        break;
                    case "5":
                        Console.WriteLine("\n Pesquisar");
                        Console.WriteLine("Digite o Nome do usuário");
                        string receber = Console.ReadLine();
                        receber = receber.ToUpper();
                        SingnUser Pesquisar = listaPessoas.Find(x => x.Nome == receber);
                        if(Pesquisar.Sexo == "M")
                        {
                            Pesquisar.Sexo = "Masculino";
                        }
                        else if(Pesquisar.Sexo == "F")
                        {
                            Pesquisar.Sexo = "Feminino";
                        }
                        Console.WriteLine($"\nNome: {Pesquisar.Nome}");
                        Console.WriteLine($"Sexo: {Pesquisar.Sexo}");
                        Console.WriteLine($"Idade: {Pesquisar.Idade}");
                        Console.WriteLine($"Email: {Pesquisar.Email}");
                        Console.WriteLine($"Quantidade de irmãos: {Pesquisar.qtdIrmaos}");
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------\n");

                        break;
                    case "00":
                        Console.WriteLine("\n Sair");
                        Console.WriteLine("Deseja sair do sistema?\n  (S) - (N)");
                        string confirmar = Console.ReadLine();
                        confirmar = confirmar.ToUpper();
                        if(confirmar == "S")
                        {
                            Continua = false;
                        }
                        else
                        {
                            Console.Clear();
                        }

                        break;

                    default:
                        Console.WriteLine("Opção não existente!");
                        break;
                }
            }
            while (Continua);

        }

        private static SingnUser IncluirPessoa()
        {
            SingnUser pessoa = new SingnUser();

            Console.WriteLine("Cadastro de usuario \n Digite os dados a seguir:");
            Console.Write("Nome:");
            pessoa.Nome = Console.ReadLine();
            pessoa.Nome = pessoa.Nome.ToUpper();
            //----------------------------------------------------
            bool sexoConfig = true;
            do
            {
                Console.Write("Sexo: (M) - (F)");
                pessoa.Sexo = Console.ReadLine();
                pessoa.Sexo = pessoa.Sexo.ToUpper();
                if (pessoa.Sexo == "M" || pessoa.Sexo == "F")
                {
                    sexoConfig = false;
                }
                else
                {
                    Console.WriteLine("*** Insira um valor aceito M - F ***");
                    sexoConfig = true;
                }
            }
            while (sexoConfig);
            //----------------------------------------------------
            bool idadeConfig = true;
            do
            {
                Console.Write("Idade:");
                pessoa.Idade = Int32.Parse(Console.ReadLine());
                if (pessoa.Idade > 100 && pessoa.Idade <= 120)
                {
                    Console.WriteLine("***Tem certeza que está é a sua idade?*** \n   (S) - (N)");
                    string conf = Console.ReadLine();
                    conf = conf.ToUpper();
                    if (conf == "S")
                    {
                        idadeConfig = false;
                    }
                    else if (conf == "N")
                    {
                        idadeConfig = true;
                    }
                }
                else if (pessoa.Idade > 120)
                {
                    Console.WriteLine("***Tá de brincadeira né!? Digite uma idade válida!***");
                    idadeConfig = true;
                }
                else
                {
                    idadeConfig = false;
                }
                Console.Write("Email:");
                pessoa.Email = Console.ReadLine();

                Console.WriteLine("Quantos irmãos você possui: ");
                pessoa.qtdIrmaos = float.Parse(Console.ReadLine());

                Console.Clear();

            }
            while (idadeConfig);

            return pessoa;
        }
    }
}
