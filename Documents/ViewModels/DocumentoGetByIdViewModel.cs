namespace Documents.ViewModels;

public class DocumentoGetByIdViewModel
{
	public int Id { get; set; }
	public string Conteudo { get; set; }
	public string State { get; set; }
	public ActionsViewModel Actions { get; set; }
}
