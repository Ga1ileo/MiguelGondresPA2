using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiguelGondresPA2.Entidades
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }

        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;
        }

    }
}
