using System;
using System.Collections.Generic;
using ControleCursos.Api.Models;
using ControleCursos.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace controleCursos.Tests
{
    public class CursoTests
    {
        [TestClass]
        public class ImovelTests
        {
            [TestMethod]
            [TestCategory("Model")]
            public void Dado_um_novo_curso_verifica_periodo()
            {
                List<Curso> cursos = new List<Curso>();
                cursos.Add(new Curso()
                {
                    descricaoAssunto = "Curso de C#",
                    dataInicio = DateTime.Now,
                    dataTermino = DateTime.Now,
                    qtdAlunosTurma = 10,
                    categoria = new Categoria() { descricao = "Programação" }
                });
                cursos.Add(new Curso()
                {
                    descricaoAssunto = "Curso de Banco de Dados",
                    dataInicio = DateTime.Now,
                    dataTermino = DateTime.Now,
                    qtdAlunosTurma = 5,
                    categoria = new Categoria() { descricao = "Programação" }
                });

                var curso = new Curso();
                curso.descricaoAssunto = "Curso de Banco de Python";
                curso.dataInicio = DateTime.Now;
                curso.dataTermino = DateTime.Now;
                curso.qtdAlunosTurma = 10;
                curso.categoria = new Categoria() { descricao = "Programação" };

                Assert.IsFalse(curso.PeriodoValido(cursos,curso));
            }
        }
    }
}
