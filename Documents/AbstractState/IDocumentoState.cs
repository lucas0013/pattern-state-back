namespace Documents.AbstractState;

public interface IDocumentoState
{
	bool CanEdit(string role);
	bool CanSave(string role);
	bool CanPublish(string role);
	bool CanApprove(string role);
	bool CanReject(string role);
	bool CanCancel(string role);
	bool CanReSubmit(string role);
	void HandleEdit(Context.Documento documento, string role);
	void HandleSave(Context.Documento documento, string role);
	void HandlePublish(Context.Documento documento, string role);
	void HandleApprove(Context.Documento documento, string role);
	void HandleReject(Context.Documento documento, string role);
	void HandleCancel(Context.Documento documento, string role);
	void HandleReSubmit(Context.Documento documento, string role);
}
