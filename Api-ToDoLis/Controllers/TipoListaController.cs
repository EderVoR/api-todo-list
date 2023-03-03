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
        public IActionResult RetornaTipos([FromQuery] int? Ativo = null)
        {
            List<TipoLista> lista;

            if(Ativo == 1)
            {
                lista = _context.TipoListas.Where(c => c.Ativo == 1).ToList();
            }
            if (Ativo == 0)
            {
                lista = _context.TipoListas.Where(c => c.Ativo == 0).ToList();
            }
            else
            {
                lista = _context.TipoListas.ToList();
            }

            List<ReadTipoLista> tipoDto = _mapper.Map<List<ReadTipoLista>>(lista);
            return Ok(tipoDto);
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

        [HttpPut("{id}")]
        public IActionResult AtualizaTipoLista(int id, [FromBody] UpdateTipoLista dto)
        {
            TipoLista lista = _context.TipoListas.FirstOrDefault(x => x.Id == id);
            if (lista == null)
                return NotFound();

            _mapper.Map(dto, lista);
            _context.SaveChanges();
            return Ok(dto);
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
