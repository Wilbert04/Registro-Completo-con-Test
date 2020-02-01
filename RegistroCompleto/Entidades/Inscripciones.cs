using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroCompleto.Entidades
{
    public class Inscripciones
    {
        [Key]
        public int IncripcionId { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public string Comentario { get; set; }
        public int Monto { get; set; }
        public int Deposito { get; set; }
        public int Balance { get; set; }

        public Inscripciones()
        {
            IncripcionId = 0;
            Fecha = DateTime.Now;
            EstudianteId = 0;
            Comentario = string.Empty;
            Monto = 0;
            Deposito = 0;
            Balance = 0;
        }
    }
}
