using Documents.AbstractState;

namespace Documents.Context;

public class Documento
{
	public int Id { get; set; }
	public string Conteudo { get; set; }
	public IDocumentoState State { get; set; }

	public void ChangeState(IDocumentoState newState)
	{
		State = newState;
	}

	public void Edit(string role)
	{
		State.HandleEdit(this, role);
	}

	public void Cancel(string role)
	{
		State.HandleCancel(this, role);


		State.HandleSave(this, role);
	}
	public void Approve(string role)
	{
		State.HandleApprove(this, role);
	}

	public void Publish(string role)
	{
		State.HandlePublish(this, role);
	}

	public void Reject(string role)
	{
		State.HandleReject(this, role);
	}

	public void Save(string role)
	{
		State.HandleSave(this, role);
	}

	public void ReSubmit(string role)
	{
		State.HandleReSubmit(this, role);
	}
}
