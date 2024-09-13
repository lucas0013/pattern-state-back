using StateExamples.VendingMachine.AbstractState;

namespace StateExamples.VendingMachine.ConcreteStates;
public class WithMoneyState : IState
{
	private Context.VendingMachine machine;

	public WithMoneyState(Context.VendingMachine machine)
	{
		this.machine = machine;
	}

	public void DeliverProduct()
	{
		Console.WriteLine("Toma o produto ai!");
	}

	public void InsertMoney(double value)
	{
		Console.WriteLine($"Dinheiro adicional inserido: {value}");
		machine.InsertMoney(value);
	}

	public void SelectProduct()
	{
		machine.TransitionTo(new DeliveringProductState(machine));
		Console.WriteLine("Produto selecionado. Entregando produto...");
		machine.SubtractMoney(machine.GetProductPrice());
		if (machine.GetActualMoney() >= machine.GetProductPrice())
			machine.TransitionTo(new WithMoneyState(machine));
		else
		{
			machine.TransitionTo(new NoMoneyState(machine));
		}
	}

	public void VerifyState()
	{

	}
}
