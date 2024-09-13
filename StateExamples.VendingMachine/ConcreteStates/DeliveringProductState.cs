using StateExamples.VendingMachine.AbstractState;

namespace StateExamples.VendingMachine.ConcreteStates;
public class DeliveringProductState : IState
{
	private Context.VendingMachine machine;

	public DeliveringProductState(Context.VendingMachine machine)
	{
		this.machine = machine;
	}

	public void DeliverProduct()
	{
		Console.WriteLine("Produto sendo entregue!");
	}

	public void InsertMoney(double value)
	{
		Console.WriteLine("Já existe um produto sendo entregue!");
	}

	public void SelectProduct()
	{
		Console.WriteLine("Produto entregue. Voltando ao estado inicial...");
		machine.TransitionTo(new NoMoneyState(machine));
	}

	public void VerifyState()
	{

	}
}
