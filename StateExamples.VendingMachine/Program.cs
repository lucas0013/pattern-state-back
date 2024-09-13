namespace StateExamples.VendingMachine;

internal class Program
{
	static void Main(string[] args)
	{
		Context.VendingMachine machine = new Context.VendingMachine();
		bool executando = true;

		while (executando)
		{
			Console.Clear();
			Console.WriteLine("=== Máquina de Vendas Automáticas ===");
			Console.WriteLine($"\n=== Estado atual: {machine.GetActualState()}===\n");
			Console.WriteLine($"Há um produto disponível, o valor é: R$ {machine.GetProductPrice()}");
			Console.WriteLine($"O total de dinheiro inserido é de: R$ {machine.GetActualMoney()}");
			Console.WriteLine("\n1. Inserir Dinheiro");
			Console.WriteLine("2. Selecionar Produto");
			Console.WriteLine("3. Sair");
			Console.Write("Escolha uma opção: ");

			string opcao = Console.ReadLine();

			switch (opcao)
			{
				case "1":
					Console.Write("Digite o valor para inserir: ");
					if (double.TryParse(Console.ReadLine(), out double valor))
					{
						machine.InsertMoney(valor);
					}
					else
					{
						Console.WriteLine("Valor inválido.");
					}
					break;

				case "2":
					machine.SelectProduct();
					break;

				case "3":
					executando = false;
					Console.WriteLine($"Saindo... Toma o seu troco de {machine.GetActualMoney()}");
					break;

				default:
					Console.WriteLine("Opção inválida.");
					break;
			}

			Console.WriteLine("\nPressione qualquer tecla para continuar...");
			Console.ReadKey();
		}
	}
}
