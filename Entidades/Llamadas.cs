﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MiguelGondresPA2.Entidades
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("LlamadaId")]
        public virtual List<LlamadaDetalle> LlamadaDetalle { get; set; }

        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;

            LlamadaDetalle = new List<LlamadaDetalle>();
        }

    }
}
