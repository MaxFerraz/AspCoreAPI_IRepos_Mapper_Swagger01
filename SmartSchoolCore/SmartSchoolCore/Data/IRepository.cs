using SmartSchoolCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchoolCore.Data
{
    public interface IRepository
    {
        //Recebe um tipo T que sera sempre uma classe
        void Add<T>(T ebtity) where T : class;
        void Update<T>(T ebtity) where T : class;
        void Delete<T>(T ebtity) where T : class;
        bool SaveChanges();

        //alunos
        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        Aluno GetAlunoByID(int alunoId, bool includeProfessor = false);

        //Professores
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        Professor GetProfessorByID(int professorId, bool includeProfessor = false);
    }
}
