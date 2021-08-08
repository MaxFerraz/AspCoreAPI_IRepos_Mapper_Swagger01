using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchoolCore.Data;
using SmartSchoolCore.Models;
using SmartSchoolCore.V1.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchoolCore.V2.Controllers
{
    /// <summary>
    /// Versão 2 do meu Controller de Alunos 
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        //private readonly SmartContext _context;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            //_context = context;
        }

        /// <summary>
        /// Método responsável para retornar todos os meus alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }


        /// <summary>
        /// Método responsável por retornar apenas um Aluno por meio do Código ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoByID(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }


        /// <summary>
        /// Metodo Adicionar
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não Cadastrado");
        }

        /// <summary>
        /// Metodo Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoDto model)
        {
            var aluno = _repo.GetAlunoByID(id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não Atualizado");
        }

        
        /// <summary>
        /// Metodo Deletar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repo.GetAlunoByID(id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }
            return BadRequest("Aluno não Deletado");
        }


        //public List<Aluno> Alunos = new List<Aluno>()
        //{
        //    new Aluno()
        //    {
        //        Id = 1,
        //        Nome = "Marcos",
        //        Telefone = "123456" 
        //    },
        //    new Aluno()
        //    {
        //        Id = 2,
        //        Nome = "Marta",
        //        Telefone = "123456"
        //    },
        //    new Aluno()
        //    {
        //        Id = 3,
        //        Nome = "Laura",
        //        Telefone = "4567899"
        //    },
        //};
    }
}
