using Documents.AbstractState;
using Documents.Context;
using Documents.Store;

namespace Documents.ConcreteStates;

public class PublicadoState : IDocumentoState
{
	public bool CanApprove(string role) => false;

	public bool CanCancel(string role) => false;

	public bool CanEdit(string role) => false;

	public bool CanPublish(string role) => false;

	public bool CanReject(string role) => false;

	public bool CanReSubmit(string role) => false;

	public bool CanSave(string role) => false;

	public void HandleApprove(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível aprovar um documento publicado.");
	}

	public void HandleCancel(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível cancelar um documento publicado.");
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
		throw new InvalidOperationException("O documento já está publicado.");
	}

	public void HandleReject(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível rejeitar um documento publicado.");
	}

	public void HandleReSubmit(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível reenviar um documento publicado.");
	}

	public void HandleSave(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível salvar um documento publicado.");
	}
}
