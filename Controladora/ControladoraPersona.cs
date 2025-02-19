using Entidades;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraPersona
    {
        private Context context;
        private static ControladoraPersona instancia;

        public static ControladoraPersona Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ControladoraPersona();
                }
                return instancia;
            }
        }

        private ControladoraPersona()
        {
            context = new Context();
        }

        // Lista todas las personas, incluyendo sus tarjetas relacionadas
        public List<Persona> ListarPersonas()
        {
            try
            {
                return context.Personas.Include(p => p.Tarjetas).ToList();
            }
            catch (Exception)
            {
                // Maneja o registra el error según convenga
                return new List<Persona>();
            }
        }

        // Crea una nueva persona en la base de datos
        public string CrearPersona(Persona persona)
        {
            try
            {
                context.Personas.Add(persona);
                context.SaveChanges();
                return "Persona creada correctamente";
            }
            catch (Exception)
            {
                return "Ocurrió un error al crear la persona";
            }
        }

        // Actualiza los datos de una persona existente
        public string ActualizarPersona(Persona persona)
        {
            try
            {
                context.Entry(persona).State = EntityState.Modified;
                context.SaveChanges();
                return "Persona actualizada correctamente";
            }
            catch (Exception)
            {
                return "Ocurrió un error al actualizar la persona";
            }
        }

        // Elimina una persona de la base de datos
        public string BorrarPersona(Persona persona)
        {
            try
            {
                var personaEncontrada = context.Personas.FirstOrDefault(p => p.PersonaId == persona.PersonaId);
                if (personaEncontrada != null)
                {
                    context.Personas.Remove(personaEncontrada);
                    context.SaveChanges();
                    return "Persona eliminada correctamente";
                }
                else
                {
                    return "Persona no encontrada";
                }
            }
            catch (Exception)
            {
                return "Ocurrió un error al eliminar la persona";
            }
        }
    }
}
