using Documents.AbstractState;
using Documents.Context;
using Documents.Store;

namespace Documents.ConcreteStates;

public class RascunhoState : IDocumentoState
{
	public bool CanApprove(string role) => false;

	public bool CanCancel(string role) => true;

	public bool CanEdit(string role) => true;

	public bool CanPublish(string role) => role == "supervisor";

	public bool CanReject(string role) => false;

	public bool CanReSubmit(string role) => false;

	public bool CanSave(string role) => true;

	public void HandleApprove(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível aprovar um documento em rascunho.");
	}

	public void HandleCancel(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível cancelar um documento em rascunho.");
	}

	public void HandleEdit(Documento documento, string role)
	{
		DocumentoStore.AddOrUpdateDocument(documento);
	}

	public void HandlePublish(Documento documento, string role)
	{
		if (role == "supervisor")
		{
			documento.ChangeState(new PublicadoState());
		}
		else
		{
			throw new InvalidOperationException("Apenas supervisores podem publicar o documento.");
		}
	}

	public void HandleReject(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível rejeitar um documento em rascunho.");
	}

	public void HandleReSubmit(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível reenviar um documento em rascunho.");
	}

	public void HandleSave(Documento documento, string role)
	{
		DocumentoStore.AddOrUpdateDocument(documento);
	}
}
