using Domain.Entities;
using Domain.Extensions;
using Domain.Utils;
using Infrastructure.IRepositories;
using Service.IServices;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class EvolucionalService : IEvolucionalService
    {
        private readonly IAlunoService _alunoService;
        private readonly IDisciplinaService _disciplinaService;
        private readonly IAlunoDisciplinaService _alunoDisciplinaService;
        private readonly IRelatorioRepository _relatorioRepository;

        public EvolucionalService(IAlunoService alunoService, IDisciplinaService DisciplinaService,
            IAlunoDisciplinaService alunoDisciplinaService, IRelatorioRepository relatorioRepository)
        {
            _alunoService = alunoService;
            _disciplinaService = DisciplinaService;
            _alunoDisciplinaService = alunoDisciplinaService;
            _relatorioRepository = relatorioRepository;
        }

        public void GerarCargaDeDados()
        {
            var listaAlunos = GerarListaDeAlunos();
            var listaDisciplinas = GerarDisciplinas();
            VincularAlunosDisciplinas(listaAlunos, listaDisciplinas);
        }

        public byte[] GerarRelatorioExcel()
        {
            var listaAlunos = _relatorioRepository.GetRelatorio();

            return listaAlunos.ToExcelFile();
        }

        private IList<Aluno> GerarListaDeAlunos()
        {
            var alunosInseridos = new List<Aluno>();

            for (int i = 0; i < 1000; i++)
            {
                var nomeAluno = $"João da silva {i}";
                Aluno aluno = _alunoService.GetBy(nomeAluno);

                if (aluno == null)
                {
                    aluno = new Aluno { Nome = nomeAluno };
                    _alunoService.Insert(aluno);
                }

                alunosInseridos.Add(aluno);
            }

            return alunosInseridos;
        }

        private IList<Disciplina> GerarDisciplinas()
        {
            var listaDisciplinas = DisciplinaUtil.GetMockDisciplinas();

            foreach (var novaDisciplina in listaDisciplinas)
            {
                var disciplina = _disciplinaService.GetBy(novaDisciplina.Codigo);

                if (disciplina == null)
                {
                    _disciplinaService.Insert(novaDisciplina);
                }
                else
                {
                    novaDisciplina.Id = disciplina.Id;
                }
            }
            return listaDisciplinas;
        }

        private void VincularAlunosDisciplinas(IList<Aluno> alunos, IList<Disciplina> disciplinas)
        {
            foreach (var aluno in alunos)
            {
                foreach (var disciplina in disciplinas)
                {
                    var random = new Random().NextDouble() * 10;
                    var nota = decimal.Round(new decimal(random), 2);

                    var novoAlunoDisciplina = new AlunoDisciplina
                    {
                        Aluno = aluno,
                        Disciplina = disciplina,
                        Nota = nota
                    };

                    var alunoDisciplina = _alunoDisciplinaService.GetBy(novoAlunoDisciplina);

                    if (alunoDisciplina == null)
                    {
                        _alunoDisciplinaService.Insert(novoAlunoDisciplina);
                    }
                }
            }
        }
    }
}
