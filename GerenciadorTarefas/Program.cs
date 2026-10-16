namespace GerenciadorTarefas;

class Program
{
    private static List<string> tarefas = [];

    static void Main(string[] args)
    {
        while (true)
        {
            ExibirMenu();
            var opcaoUsuario = Console.ReadLine();
            switch (opcaoUsuario)
            {
                case "1":
                    AdicionarTarefa();
                    break;
                case "2":
                    ListarTarefas();
                    break;
                case "3":
                    BuscarTarefaPorPalavraChave();
                    break;
                case "4":
                    Sair();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }

            Console.WriteLine("Aperte qualquer tecla para continuar!");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void Sair()
    {
        Console.WriteLine("Saindo do programa...");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }

    private static void BuscarTarefaPorPalavraChave()
    {
        Console.Write("Digite o termo a ser buscado: ");
        var palavraChave = Console.ReadLine();
        bool encontrado = false;
        Console.WriteLine("----- Resultado da Busca -----");
        foreach (var tarefa in tarefas)
        {
            if (tarefa.Contains(palavraChave, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"- {tarefa}");
                encontrado = true;
            }
        }

        if (!encontrado)
        { 
            Console.WriteLine("Termo não encontrado!");    
        }
    }

    private static void ListarTarefas()
    {
        if (tarefas.Count < 1)
        {
            Console.WriteLine("Não há tarefas cadastradas!");
        }
        else
        {
            Console.WriteLine("----- Suas Tarefas -----");
            foreach (var tarefa in tarefas)
            {
                Console.WriteLine($"- {tarefa}");
            }
        }
    }

    private static void AdicionarTarefa()
    {
        Console.Write("Digite a descrição da sua tarefa: ");
        var novaTarefa = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(novaTarefa))
        {
            Console.WriteLine("A tarefa não foi adicionada pois está vazia!");
        }
        else
        {
            tarefas.Add(novaTarefa);
            Console.WriteLine("A tarefa foi adicionada com sucesso!");
        }
    }

    private static void ExibirMenu()
    {
        Console.WriteLine("----- Gerenciador de Tarefas -----");
        Console.WriteLine("1. Adicionar tarefa");
        Console.WriteLine("2. Listar tarefas");
        Console.WriteLine("3. Buscar tarefa por palavra-chave");
        Console.WriteLine("4. Sair");
        Console.Write("Escolha sua opção: ");
    }
}