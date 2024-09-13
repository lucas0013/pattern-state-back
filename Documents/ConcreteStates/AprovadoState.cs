using Documents.AbstractState;
using Documents.Context;
using Documents.Store;

namespace Documents.ConcreteStates;

public class AprovadoState : IDocumentoState
{
	public bool CanApprove(string role) => false;

	public bool CanCancel(string role) => role == "supervisor";

	public bool CanEdit(string role) => false;

	public bool CanPublish(string role) => role == "supervisor";

	public bool CanReject(string role) => false;

	public bool CanReSubmit(string role) => false;

	public bool CanSave(string role) => false;
	public void HandleApprove(Documento documento, string role)
	{
		throw new InvalidOperationException("O documento já está aprovado.");
	}

	public void HandleCancel(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível cancelar um documento aprovado.");
	}

	public void HandleEdit(Documento documento, string role)
	{
		if (role == "supervisor")
		{
			DocumentoStore.AddOrUpdateDocument(documento);
		}
		else
		{
			throw new InvalidOperationException("Apenas supervisores podem editar o documento.");
		}
	}

	public void HandlePublish(Documento documento, string role)
	{
		documento.ChangeState(new PublicadoState());
	}

	public void HandleReject(Documento documento, string role)
	{
		if (role == "supervisor")
		{
			documento.ChangeState(new RejeitadoState());
		}
		else
		{
			throw new InvalidOperationException("Apenas supervisores podem rejeitar o documento.");
		}
	}

	public void HandleReSubmit(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível reenviar um documento aprovado.");
	}

	public void HandleSave(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível salvar um documento aprovado.");
	}
}
