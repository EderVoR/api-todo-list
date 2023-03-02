using Api_ToDoLis.Data;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Api_ToDoLis.Data.Dto.ToDoList;
using Api_ToDoLis.Models;

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
        public IActionResult RetornaTarefas()
        {
            List<ToDoList> tarefas = _context.ToDoLists.ToList();
            ReadToDoList dtoLista = _mapper.Map<ReadToDoList>(tarefas);
            return Ok(dtoLista);
        }

        [HttpGet("{id}")]
        public IActionResult RetornaTarefas(int id)
        {
            ToDoList tarefa = _context.ToDoLists.FirstOrDefault(x => x.Id == id);
            if(tarefa == null)
                return NotFound();

            ReadToDoList dtoLista = _mapper.Map<ReadToDoList>(tarefa);
            return Ok(dtoLista);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveTarefa(int id)
        {
            ToDoList tarefa = _context.ToDoLists.FirstOrDefault(x => x.Id == id);
            if (tarefa == null)
                return NotFound();

            _context.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
