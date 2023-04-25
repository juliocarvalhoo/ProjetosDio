using InterfacesClasses.Enum;
using InterfacesClasses.Classes;
using static System.Console;

namespace InterfacesClasses.Classes
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main()
        {
            string OpcaoUsuario = ObterOpcaoUsuario();
            while(OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case"1":
                        ListarSerie();
                        break;
                    case"2":
                        InserirSerie();
                        break;
                    case"3":
                        AtualizarSerie();
                        break;
                    case"4":
                        Excluirserie();
                        break;
                    case"5":
                        VisualizarSerie();
                        break;
                    case"C":
                        VisualizarSerie();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario=ObterOpcaoUsuario();
            }
            WriteLine("Obrigado por utilizar os nossos serviços.");
            ReadLine();
        }

        private static void ListarSerie()
        {
            WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count==0)
            {
                WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }
        private static void InserirSerie()
        {
            WriteLine("Inserir nova série");

            foreach(int i in Genero.GetValues(typeof(Genero)))
            {
                WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero),i));
            }
            Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(ReadLine());

            Write("Digite o titulo da Série: ");
            string entradaTitulo = ReadLine();

            Write("Digite o ano da Série: ");
            int entradaAno = int.Parse(ReadLine());

            Write("Digite a descricao da Série: ");
            string entradaDescricao = ReadLine();

            Serie novaSerie =  new Serie(id: repositorio.ProximoId(),
                                         genero:(Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         descricao: entradaDescricao,
                                         ano: entradaAno
                                         
                                        );

            repositorio.Insere(novaSerie);

        }

         private static void AtualizarSerie()
        {
            WriteLine("Digite o id da série:");
            int indice = int.Parse(ReadLine());

            foreach(int i in Genero.GetValues(typeof(Genero)))
            {
                WriteLine("{0} - {1}", i, Genero.GetName(typeof(Genero),i));
            }
            Write("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(ReadLine());

            Write("Digite o titulo da Série: ");
            string entradaTitulo = ReadLine();

            Write("Digite o ano da Série: ");
            int entradaAno = int.Parse(ReadLine());

            Write("Digite a descricao da Série: ");
            string entradaDescricao = ReadLine();

            Serie atualizandoserie=  new Serie(id: indice,
                                         genero:(Genero)entradaGenero,
                                         titulo: entradaTitulo,
                                         descricao: entradaDescricao,
                                         ano: entradaAno
                                         
                                        );

            repositorio.Atualiza(indice, atualizandoserie);

        }

        private static void Excluirserie()
        {
            Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            WriteLine("Digite o id da série:");
            int indiceSerie = int.Parse(ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario()
        {
            WriteLine();
            WriteLine("Séries a seu dispor!!!");
            WriteLine("Informe a opção desejada:");

            WriteLine("1- Listar séries");
            WriteLine("2- Inserir nova série");
            WriteLine("3- Atualizar série");
            WriteLine("4- Excluir série");
            WriteLine("5- Visualizar série");
            WriteLine("C- Limpar Tela");
            WriteLine("X- Sair");
            WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }    
}