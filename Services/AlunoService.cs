using AlunosAPI.Context;
using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AlunosAPI.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAluno(Aluno aluno)
        {
            aluno.Id = Guid.NewGuid();
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<Aluno> GetAluno(Guid Id)
        {
            return await _context.Alunos.FindAsync(Id);
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Aluno>> GetAlunosByName(string Nome)
        {
            try
            {
                if (!string.IsNullOrEmpty(Nome))
                {
                    return await _context.Alunos.Where(a => a.Nome.Contains(Nome)).ToListAsync();
                }
                else
                    return await GetAlunos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
