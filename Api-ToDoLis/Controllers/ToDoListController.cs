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


    }
}
