using AlunosAPI.Models;
using System.Collections.Generic;
using System.Globalization;

namespace AlunosAPI.Services;

public interface IAlunoService
{
    Task<IEnumerable<Aluno>> GetAlunos();
    Task<Aluno> GetAluno(Guid Id);
    Task<IEnumerable<Aluno>> GetAlunosByName(string Nome);
    Task CreateAluno(Aluno aluno);
    Task UpdateAluno(Aluno aluno);
    Task DeleteAluno(Aluno aluno);
}
