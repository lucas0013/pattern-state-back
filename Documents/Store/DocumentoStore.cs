namespace Documents.Store;
public static class DocumentoStore
{
	private static readonly Dictionary<int, Context.Documento> _documents = new();

	public static Context.Documento GetDocumentById(int id) => _documents.TryGetValue(id, out var doc) ? doc : null;
	public static void AddOrUpdateDocument(Context.Documento documento) => _documents[documento.Id] = documento;
	public static void RemoveDocument(int id) => _documents.Remove(id);
	public static IEnumerable<Context.Documento> GetAllDocuments() => _documents.Values;
}
