using Documents.Store;
using Documents.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Documents.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DocumentoController : ControllerBase
{
	public DocumentoController()
	{

	}

	[HttpGet()]
	public IEnumerable<DocumentoGetViewModel> Get()
	{
		return DocumentoStore.GetAllDocuments().Select(d => new DocumentoGetViewModel
		{
			Id = d.Id,
			Conteudo = d.Conteudo,
			State = d.State.ToString()
		});
	}

	[HttpGet("{id}")]
	public ActionResult<DocumentoGetByIdViewModel> Get(int id, [FromQuery] string role)
	{
		var documento = DocumentoStore.GetDocumentById(id);
		if (documento == null)
		{
			return NotFound();
		}

		var actions = new ActionsViewModel
		{
			isEditButtonEnabled = documento.State.CanEdit(role),
			isSaveButtonEnabled = documento.State.CanSave(role),
			isPublishButtonEnabled = documento.State.CanPublish(role),
			isApproveButtonEnabled = documento.State.CanApprove(role),
			isRejectButtonEnabled = documento.State.CanReject(role),
			isCancelButtonEnabled = documento.State.CanCancel(role),
			isReSubmitButtonEnabled = documento.State.CanReSubmit(role)
		};

		return new DocumentoGetByIdViewModel
		{
			Id = documento.Id,
			Conteudo = documento.Conteudo,
			State = documento.State.ToString(),
			Actions = actions
		};
	}

	[HttpPost]
	public ActionResult<DocumentoGetViewModel> Post([FromBody] DocumentoPostViewModel model)
	{
		var documento = new Context.Documento
		{
			Id = DocumentoStore.GetAllDocuments().Count() + 1,
			Conteudo = model.Conteudo,
			State = new ConcreteStates.RascunhoState()
		};

		DocumentoStore.AddOrUpdateDocument(documento);

		return new DocumentoGetViewModel
		{
			Id = documento.Id,
			Conteudo = documento.Conteudo,
			State = documento.State.ToString()
		};
	}

	[HttpPost("{id}/save")]
	public ActionResult Save(int id, [FromQuery] string role)
	{
		var documento = DocumentoStore.GetDocumentById(id);
		if (documento == null)
		{
			return NotFound();
		}

		if (documento.State is ConcreteStates.RascunhoState)
		{
			documento.State = new ConcreteStates.AguardandoAprovacaoState();
			DocumentoStore.AddOrUpdateDocument(documento);
			return Ok("");
		}

		return BadRequest("Ação não permitida no estado atual.");
	}

	[HttpPost("{id}/publish")]
	public ActionResult Publish(int id, [FromQuery] string role)
	{
		var documento = DocumentoStore.GetDocumentById(id);
		if (documento == null)
		{
			return NotFound();
		}

		if ((documento.State is ConcreteStates.AprovadoState) || (role == "supervisor" && documento.State is ConcreteStates.RascunhoState))
		{
			documento.State.HandlePublish(documento, role);
			return Ok("");
		}

		return BadRequest("Ação não permitida no estado atual.");
	}

	[HttpPost("{id}/approve")]
	public ActionResult Approve(int id, [FromQuery] string role)
	{
		var documento = DocumentoStore.GetDocumentById(id);
		if (documento == null)
		{
			return NotFound();
		}

		if (documento.State is ConcreteStates.AguardandoAprovacaoState)
		{
			documento.State.HandleApprove(documento, role);
			return Ok("");
		}

		return BadRequest("Ação não permitida no estado atual.");
	}

	[HttpPost("{id}/reject")]
	public ActionResult Reject(int id, [FromQuery] string role)
	{
		var documento = DocumentoStore.GetDocumentById(id);
		if (documento == null)
		{
			return NotFound();
		}

		if (documento.State is ConcreteStates.AguardandoAprovacaoState)
		{
			documento.State.HandleReject(documento, role);
			return Ok("");
		}

		return BadRequest("Ação não permitida no estado atual.");
	}

	[HttpPost("{id}/resubmit")]
	public ActionResult ReSubmit(int id, [FromQuery] string role)
	{
		var documento = DocumentoStore.GetDocumentById(id);
		if (documento == null)
		{
			return NotFound();
		}

		if (documento.State is ConcreteStates.RejeitadoState)
		{
			documento.State.HandleReSubmit(documento, role);
			return Ok("");
		}

		return BadRequest("Ação não permitida no estado atual.");
	}
}

