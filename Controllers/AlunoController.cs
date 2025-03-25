using AlunosAPI.Models;
using AlunosAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
    {
        try
        {
            var alunos = await _alunoService.GetAlunos();
            return Ok(alunos);
        }
        catch (Exception)
        {
            return BadRequest("Error");
        }
    }
    [HttpGet("Id:{Id}", Name = "GetAluno")]
    public async Task<ActionResult<Aluno>> GetAluno([FromQuery] Guid Id)
    {
        try
        {
            var alunos = await _alunoService.GetAluno(Id);
            if (alunos == null)
                return NotFound("nenhum aluno encontrado");
            return Ok(alunos);
        }
        catch (Exception)
        {
            return BadRequest("Error");
        }
    }
    [HttpGet("Nome:{Nome}")]
    public async Task<ActionResult<Aluno>> GetAlunoByName(string Nome)
    {
        try
        {
            var alunos = await _alunoService.GetAlunosByName(Nome);
            if (alunos == null)
                return NotFound("nenhum aluno encontrado");            
            return Ok(alunos);
        }
        catch (Exception)
        {
            return BadRequest("Error");
        }
    }
    [HttpPost]
    public async Task<ActionResult<Aluno>> Create(Aluno aluno)
    {
        try
        {
            await _alunoService.CreateAluno(aluno);
           
            return CreatedAtRoute(nameof(GetAluno),new { id = aluno.Id}, aluno);
        }
        catch (Exception)
        {
            return BadRequest("Error");
        }
    }
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult<Aluno>> Update(Guid id,[FromBody] Aluno aluno)
    {
        try
        {
            if (id == aluno.Id)
            {
                await _alunoService.UpdateAluno(aluno);
                return Ok();
            }
            else
                return BadRequest("Dados inconsistente");
            
        }
        catch (Exception)
        {
            return BadRequest("Error");
        }
    }
    [HttpDelete]
    public async Task<ActionResult<Aluno>> Delete(Guid id)
    {
        try
        {
            var aluno = await _alunoService.GetAluno(id);
            await _alunoService.DeleteAluno(aluno);
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Error");
        }
    }


}
