﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        // Considera agregar mas propiedades segun los requisitos del sistema
        public Persona() 
        {
            Nombre = "";
            Apellido = "";
            DNI = "";
        }
        public Persona(string nombre, string apellido, string dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
        }

        // Relaciones (si aplicable)
        public virtual List<Tarjeta> Tarjetas { get; set; } = new List<Tarjeta>();
    }

}