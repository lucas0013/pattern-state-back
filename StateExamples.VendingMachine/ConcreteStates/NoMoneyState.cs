using StateExamples.VendingMachine.AbstractState;

namespace StateExamples.VendingMachine.ConcreteStates;
public class NoMoneyState : IState
{
	private Context.VendingMachine machine;

	public NoMoneyState(Context.VendingMachine machine)
	{
		this.machine = machine;
	}
	public void DeliverProduct()
	{
		Console.WriteLine("Dinheiro insuficiente, por favor, insira mais dinheiro!");
		VerifyState();
	}

	public void InsertMoney(double value)
	{
		Console.WriteLine($"Dinheiro inserido : {value}");
		machine.InsertMoney(value);
		VerifyState();
	}

	public void SelectProduct()
	{
		Console.WriteLine("Dinheiro insuficiente, por favor, insira mais dinheiro!");
		VerifyState();
	}

	public void VerifyState()
	{
		if (machine.GetActualMoney() >= machine.GetProductPrice())
			machine.TransitionTo(new WithMoneyState(machine));
		else
		{
			machine.TransitionTo(new NoMoneyState(machine));
		}
	}
}
