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
                    DescricaoAssunto = "Curso de C#",
                    DataInicio = DateTime.Now,
                    DataTermino = DateTime.Now,
                    QtdAlunosTurma = 10,
                    Categoria = new Categoria() { Descricao = "Programação" }
                });
                cursos.Add(new Curso()
                {
                    DescricaoAssunto = "Curso de Banco de Dados",
                    DataInicio = DateTime.Now,
                    DataTermino = DateTime.Now,
                    QtdAlunosTurma = 5,
                    Categoria = new Categoria() { Descricao = "Programação" }
                });

                var curso = new Curso();
                curso.DescricaoAssunto = "Curso de Banco de Python";
                curso.DataInicio = DateTime.Now;
                curso.DataTermino = DateTime.Now;
                curso.QtdAlunosTurma = 10;
                curso.Categoria = new Categoria() { Descricao = "Programação" };

                Assert.IsFalse(curso.PeriodoValido(cursos,curso));
            }
        }
    }
}
