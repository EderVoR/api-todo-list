using Api_ToDoLis.Data;
using Api_ToDoLis.Data.Dto.ToDoList;
using Api_ToDoLis.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_ToDoLis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public ToDoListController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaTarefa(CreateToDoList dto)
        {
            ToDoList tarefa = _mapper.Map<ToDoList>(dto);
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpGet]
        public IActionResult RetornaTarefas([FromBody] int? Concluido = null)
        {
            List<ToDoList> tarefas;
            if(Concluido == 0)
                tarefas = _context.ToDoLists.Where(x => x.Concluido == 0).ToList();
            if(Concluido == 1)
                tarefas = _context.ToDoLists.Where(x => x.Concluido == 1).ToList();
            else
                tarefas = _context.ToDoLists.ToList();
            
            ReadToDoList dtoLista = _mapper.Map<ReadToDoList>(tarefas);
            return Ok(dtoLista);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaTarefas(int id)
        {
            ToDoList tarefa = ConsultaId(id);
            if(tarefa == null)
                return NotFound();

            ReadToDoList dtoLista = _mapper.Map<ReadToDoList>(tarefa);
            return Ok(dtoLista);
        }

        [HttpPut]
        public IActionResult AtualizaListaTarefa(int id, [FromBody] UpdateToDoList dto)
        {
            ToDoList tarefa = ConsultaId(id);
            if (tarefa == null)
                return NotFound();

            _mapper.Map(dto, tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTarefa(int id)
        {
            ToDoList tarefa = ConsultaId(id);
            if (tarefa == null)
                return NotFound();

            _context.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }

        private ToDoList ConsultaId(int id)
        {
            ToDoList tarefa = _context.ToDoLists.FirstOrDefault(x => x.Id == id);
            return tarefa;
        }
    }
}
