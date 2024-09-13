using Documents.AbstractState;
using Documents.Context;
using Documents.Store;

namespace Documents.ConcreteStates;

public class AguardandoAprovacaoState : IDocumentoState
{
	public bool CanApprove(string role) => role == "supervisor";

	public bool CanCancel(string role) => true;

	public bool CanEdit(string role) => true;

	public bool CanPublish(string role) => false;

	public bool CanReject(string role) => role == "supervisor";

	public bool CanReSubmit(string role) => false;

	public bool CanSave(string role) => false;

	public void HandleApprove(Documento documento, string role)
	{
		if (role == "supervisor")
		{
			documento.ChangeState(new AprovadoState());
		}
		else
		{
			throw new InvalidOperationException("Apenas supervisores podem aprovar o documento.");
		}
	}

	public void HandleCancel(Documento documento, string role)
	{
		if (role == "funcionario")
		{
			documento.ChangeState(new RascunhoState());
		}
		else
		{
			throw new InvalidOperationException("Apenas funcionários podem cancelar o documento.");
		}
	}

	public void HandleEdit(Documento documento, string role)
	{
		if (role == "funcionario")
		{
			DocumentoStore.AddOrUpdateDocument(documento);
		}
		else
		{
			throw new InvalidOperationException("Apenas funcionários podem editar o documento.");
		}
	}

	public void HandlePublish(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível publicar um documento que está aguardando aprovação.");
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
		throw new InvalidOperationException("Não é possível reenviar um documento que está aguardando aprovação.");
	}

	public void HandleSave(Documento documento, string role)
	{
		throw new InvalidOperationException("Não é possível salvar um documento que está aguardando aprovação.");
	}
}
