using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitectureV3.Api.DTO;
using CleanArchitectureV3.Api.Filters;
using CleanArchitectureV3.Core.Entities;
using CleanArchitectureV3.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureV3.Api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    public class ToDoItemsController : Controller
    {
        private readonly IRepository<ToDoItem> _repository;
        private readonly IMapper _mapper;

        public ToDoItemsController(IRepository<ToDoItem> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List().Select(x => _mapper.Map<ToDoItem, ToDoItemDTO>(x));
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _mapper.Map<ToDoItem, ToDoItemDTO>(_repository.GetById(id));
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ToDoItemDTO dto)
        {
            var item = _mapper.Map<ToDoItemDTO, ToDoItem>(dto);
            _repository.Add(item);

            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(item));
        }

        [HttpGet("{id:int}/complete")]
        public IActionResult Complete(int id)
        {
            var item = _repository.GetById(id);
            item.MarkComplete();
            _repository.Update(item);

            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(item));
        }

        [HttpPatch]
        public IActionResult Complete([FromBody] ToDoItemDTO dto)
        {
            var item = _mapper.Map<ToDoItemDTO, ToDoItem>(dto);
            item.MarkComplete();
            _repository.Update(item);

            return Ok(_mapper.Map<ToDoItem, ToDoItemDTO>(item));
        }
    }
}