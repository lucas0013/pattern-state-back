using StateExamples.VendingMachine.AbstractState;
using StateExamples.VendingMachine.ConcreteStates;

namespace StateExamples.VendingMachine.Context;
public class VendingMachine
{
	private IState actualState;
	private double money;
	private double productPrice;
	public VendingMachine()
	{
		actualState = new NoMoneyState(this);
		money = 0;
		productPrice = 2.0;
	}

	// para interagir com a máquina

	public void InsertMoney(double value)
	{
		money += value;
		actualState.VerifyState();
	}

	public void SelectProduct()
	{
		actualState.SelectProduct();
	}

	// para mudar de estado
	public void TransitionTo(IState newState)
	{
		Console.WriteLine($"Context: Transition to {newState.GetType().Name}.");
		actualState = newState;
	}

	// auxiliares

	public void SubtractMoney(double value)
	{
		money -= value;
	}

	public double GetProductPrice()
	{
		return productPrice;
	}

	public double GetActualMoney()
	{
		return money;
	}

	public string GetActualState()
	{
		return actualState.GetType().Name;
	}
}
