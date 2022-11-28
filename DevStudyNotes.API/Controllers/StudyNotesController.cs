using DevStudyNotes.API.Entities;
using DevStudyNotes.API.Models;
using DevStudyNotes.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevStudyNotes.API.Controllers
{
    [ApiController]
    [Route("api/study-notes")]
    public class StudyNotesController : ControllerBase
    {
        private readonly StudyNoteDbContext _context;

        public StudyNotesController(StudyNoteDbContext context)
            => _context = context;

        // GET: api/study-notes
        /// <summary>
        /// Listagem de Notas de Estudo
        /// </summary>
        /// <returns>Lista de Notas de Estudo</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var studyNotes = _context.StudyNotes.ToList();

            return Ok(studyNotes);
        }

        // GET: api/study-notes/{id}
        /// <summary>
        /// Detalhes da Nota de Estudo
        /// </summary>
        /// <param name="id">ID da Nota de Estudo</param>
        /// <returns>Mostra uma Nota de Estudo</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var studyNote = _context.StudyNotes.Include(s => s.Reactions).SingleOrDefault(s => s.Id == id);

            if (studyNote == null)
                return NotFound("Nota de Estudo não encontrada.");

            return Ok(studyNote);
        }

        // POST: api/study-notes
        /// <summary>
        /// Cadastro de Nota de Estudo
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "title": "Estudos AZ-400",
        ///     "description": "Sobre o Azure Blob Storage",
        ///     "isPublic": true
        /// }
        /// </remarks>
        /// <param name="model">Dados da Nota de Estudo</param>
        /// <returns>Objeto criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(AddStudyNoteInputModel model)
        {
            var studyNote = new StudyNote(model.Title, model.Description, model.IsPublic);

            _context.StudyNotes.Add(studyNote);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = studyNote.Id }, model);
        }

        // POST: api/study-notes/{id}/reactions
        /// <summary>
        /// Cadastro de Reações da Nota de Estudo
        /// </summary>
        /// <remarks>
        /// Requisição:
        /// {
        ///     "studyNoteId": 1,
        ///     "isPositive": true
        /// }
        /// </remarks>
        /// <param name="id">ID da Nota de Estudo</param>
        /// <param name="model">Dados da Reação da Nota de Estudo</param>
        /// <returns>Objeto criado</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="400">Dados inválidos</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost("{id}/reactions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PostReaction(int id, AddReactionStudyNoteInputModel model)
        {
            var studyNote = _context.StudyNotes.SingleOrDefault(s => s.Id == id);

            if (studyNote == null)
                return NotFound("Nota de Estudo não encontrada.");

            studyNote.AddReaction(model.IsPositive);

            _context.SaveChanges();

            return NoContent();
        }
    }
}