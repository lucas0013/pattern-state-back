namespace StateExamples.VendingMachine.AbstractState;
public interface IState
{
	public void InsertMoney(double value);
	public void SelectProduct();
	public void DeliverProduct();
	public void VerifyState();
}
