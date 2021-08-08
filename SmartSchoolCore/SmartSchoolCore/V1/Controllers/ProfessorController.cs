using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchoolCore.Data;
using SmartSchoolCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchoolCore.V1.Controllers
{
    /// <summary>
    /// Versão 1 do meu Controller de Professores
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        //private readonly SmartContext _context;
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            //_context = context;
        }



        // GET: api/<ProfessorController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        
        // GET api/<ProfessorController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetProfessorByID(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não Cadastrado");
        }


        // PUT api/<ProfessorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var prof = _repo.GetProfessorByID(id);
            if (prof == null) return BadRequest("O Professor não foi encontrado");
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não Atualizado");
        }


        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prof = _repo.GetProfessorByID(id, false);
            if (prof == null) return BadRequest("Professor não foi encontrado");
            _repo.Delete(prof);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }
            return BadRequest("Professor não Deletado");
        }
    }
}
