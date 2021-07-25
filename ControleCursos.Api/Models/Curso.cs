using ControleCursos.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControleCursos.Data
{
    public class Curso
    {

        public int Codigo { get; set; }
        public string DescricaoAssunto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int QtdAlunosTurma { get; set; }
        public Categoria Categoria { get; set; }

        public Boolean PeriodoValido(List<Curso> cursos, Curso curso)
        {
            foreach (Curso aPart in cursos)
            {
                if(aPart.DataInicio.Month == curso.DataInicio.Month) { return false; }
            }

            return true;
        }
    }
}
