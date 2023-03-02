using Api_ToDoLis.Data;
using Api_ToDoLis.Data.Dto.TipoLista;
using Api_ToDoLis.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_ToDoLis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoListaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TipoListaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastraTipoLista(CreateTipoLista dto)
        {
            TipoLista tipo = _mapper.Map<TipoLista>(dto);
            _context.Add(tipo);
            _context.SaveChanges();
            return Ok(tipo);
        }

        [HttpGet]
        public IActionResult RetornaTipos()
        {
            List<TipoLista> lista;
            lista = _context.TipoListas.ToList();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaTiposPorId(int id)
        {
            TipoLista lista = _context.TipoListas.FirstOrDefault(x => x.Id == id);
            if (lista == null)
                return NotFound();

            ReadTipoLista dtoLista = _mapper.Map<ReadTipoLista>(lista);
            return Ok(dtoLista);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaTipoLista(int id)
        {
            TipoLista lista = _context.TipoListas.FirstOrDefault(x => x.Id == id);
            if (lista == null)
                return NotFound();

            _context.Remove(lista);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
