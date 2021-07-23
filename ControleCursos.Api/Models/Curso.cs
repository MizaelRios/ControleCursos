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

        public int codigo { get; set; }
        public string descricaoAssunto { get; set; }
        public DateTime dataInicio { get; set; }
        public DateTime dataTermino { get; set; }
        public int qtdAlunosTurma { get; set; }
        public Categoria categoria { get; set; }

        public Boolean PeriodoValido(List<Curso> cursos, Curso curso)
        {
            foreach (Curso aPart in cursos)
            {
                if(aPart.dataInicio.Month == curso.dataInicio.Month) { return false; }
            }

            return true;
        }
    }
}
