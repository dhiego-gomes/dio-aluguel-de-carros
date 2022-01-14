using System;

namespace DIO.AluguelDeCarros
{
    class program
    {
        static CarroRepositorio repositorio = new CarroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarCarros();
                            break;                    
                        case "2":
                            InserirCarro();
                            break;
                        case "3":
                            AtualizarCarro();
                            break;
                        case "4":
                            ExcluirCarro();
                            break;
                        case "5":
                            VisualizarCarro();
                            break;
                        case "6":
                            AlugarCarro();
                            break;
                        case "7":
                            DevolverCarro();
                            break;
                        case "C":
                            Console.Clear();
                            break;
                    }
                    
                    opcaoUsuario = ObterOpcaoUsuario();
                }
                
                System.Console.WriteLine("Saindo...");
                System.Console.WriteLine();
        }

        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("=== ALUGUEL DE CARROS ===");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1 - Listar carros disponíveis");
            System.Console.WriteLine("2 - Inserir novo carro");
            System.Console.WriteLine("3 - Atualizar informações do carro");
            System.Console.WriteLine("4 - Excluir carro");
            System.Console.WriteLine("5 - Visualizar carro");
            System.Console.WriteLine("6 - Alugar carro");
            System.Console.WriteLine("7 - Devolver carro");
            System.Console.WriteLine("C - LIMPAR TELA");
            System.Console.WriteLine("X - SAIR");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            System.Console.WriteLine();

            return opcaoUsuario;
        }

        private static void ListarCarros()
        {
            System.Console.WriteLine("=== Listar Carros ===");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Não há carros cadastrados.");
                return;
            } 
            
            foreach (var carro in lista)
            {
                var excluido = carro.RetornaExcluido();
                var alugado = carro.RetornaAlugado();
                System.Console.WriteLine($"#ID - {carro.RetornaId()}: {carro.RetornaModelo()} {(excluido ? "| (!)Excluído" : "")} {(alugado ? "| (!)Alugado" : "")}");
            }
        }

        private static void InserirCarro()

        {
            System.Console.WriteLine("=== Inserir novo carro ===");
            foreach(int i in Enum.GetValues(typeof(Tipo)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Tipo), i)}");
            }

            System.Console.WriteLine("Digite o tipo entre as opções acima:");
            int entradaTipo = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Digite o nome do carro");
            string entradaModelo = Console.ReadLine();
            
            System.Console.WriteLine("Digite a cor do carro");
            string entradaCor = Console.ReadLine();
            
            System.Console.WriteLine("Digite o ano de fabricação e do modelo do carro");
            string entradaAno = Console.ReadLine();
            
            System.Console.WriteLine("Digite a quilometragem do carro");
            int entradaKm = int.Parse(Console.ReadLine());      

            Carro novoCarro = new Carro(
                id: repositorio.ProximoId(),
                tipo: (Tipo)entradaTipo,
                modelo: entradaModelo,
                cor: entradaCor,
                ano: entradaAno,
                km: entradaKm
            );

            repositorio.Insere(novoCarro);
        }

        private static void AtualizarCarro()
        {
            System.Console.WriteLine("Digite o ID do carro:");
            int indiceCarro = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Tipo)))
            {
                System.Console.WriteLine($"{i} - {Enum.GetName(typeof(Tipo), i)}");
            }

            System.Console.WriteLine("Digite o tipo entre as opções acima:");
            int entradaTipo = int.Parse(Console.ReadLine());
            
            System.Console.WriteLine("Digite o nome do carro");
            string entradaModelo = Console.ReadLine();
            
            System.Console.WriteLine("Digite a cor do carro");
            string entradaCor = Console.ReadLine();
            
            System.Console.WriteLine("Digite o ano de fabricação e do modelo do carro");
            string entradaAno = Console.ReadLine();
            
            System.Console.WriteLine("Digite a quilometragem do carro");
            int entradaKm = int.Parse(Console.ReadLine());      

            Carro atualizaCarro = new Carro(
                id: indiceCarro,
                tipo: (Tipo)entradaTipo,
                modelo: entradaModelo,
                cor: entradaCor,
                ano: entradaAno,
                km: entradaKm
            );

            repositorio.Atualiza(indiceCarro, atualizaCarro);
        }

        private static void ExcluirCarro()
        {
            System.Console.WriteLine("Digite o ID do carro:");
            int indiceCarro = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceCarro);
        }

        private static void VisualizarCarro()
        {
            System.Console.WriteLine("Digite o ID do carro:");
            int indiceCarro = int.Parse(Console.ReadLine());

            var carro = repositorio.RetornaPorId(indiceCarro);

            System.Console.WriteLine(carro);
        }

        private static void AlugarCarro()
        {
            System.Console.WriteLine("Digite o ID do carro:");
            int indiceCarro = int.Parse(Console.ReadLine());

            repositorio.Aluga(indiceCarro);
        }
        private static void DevolverCarro()
        {
            System.Console.WriteLine("Digite o ID do carro:");
            int indiceCarro = int.Parse(Console.ReadLine());

            repositorio.Devolve(indiceCarro);
        }
    }
}