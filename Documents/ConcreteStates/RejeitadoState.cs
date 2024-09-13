using Documents.AbstractState;
using Documents.Context;
using Documents.Store;

namespace Documents.ConcreteStates;

public class RejeitadoState : IDocumentoState
{
	public bool CanApprove(string role) => false;


	public bool CanCancel(string role) => true;
	public bool CanEdit(string role) => true;
	public bool CanPublish(string role) => false;
	public bool CanReject(string role) => false;
	public bool CanReSubmit(string role) => true;
	public bool CanSave(string role) => false;
	public void HandleApprove(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível aprovar um documento rejeitado.");
	}

	public void HandleCancel(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível cancelar um documento rejeitado.");
	}

	public void HandleEdit(Documento documento, string role)
	{
		DocumentoStore.AddOrUpdateDocument(documento);
	}

	public void HandlePublish(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível publicar um documento rejeitado.");
	}

	public void HandleReject(Documento documento, string role)
	{
		throw new InvalidOperationException("O documento já está rejeitado.");
	}

	public void HandleReSubmit(Documento documento, string role)
	{
		documento.ChangeState(new AguardandoAprovacaoState());
	}

	public void HandleSave(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível salvar um documento rejeitado.");
	}
}
