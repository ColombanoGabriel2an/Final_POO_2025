using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controladora
{
    public class ControladoraPersona
    {
        private List<Persona> personas;
        private static ControladoraPersona? instancia;

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
            personas = new List<Persona>();
        }

        // Lista todas las personas
        public List<Persona> ListarPersonas()
        {
            try
            {
                return personas;
            }
            catch (Exception)
            {
                return new List<Persona>();
            }
        }

        // Crea una nueva persona en la lista
        public string CrearPersona(Persona persona)
        {
            try
            {
                // Generar ID si es necesario
                if (persona.PersonaId <= 0)
                {
                    persona.PersonaId = personas.Count > 0
                        ? personas.Max(p => p.PersonaId) + 1 : 1;
                }

                personas.Add(persona);
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
                var personaExistente = personas.FirstOrDefault(p => p.PersonaId == persona.PersonaId);
                if (personaExistente != null)
                {
                    // Elimina la persona anterior y agrega la actualizada
                    personas.Remove(personaExistente);
                    personas.Add(persona);
                    return "Persona actualizada correctamente";
                }
                else
                {
                    return "Persona no encontrada";
                }
            }
            catch (Exception)
            {
                return "Ocurrió un error al actualizar la persona";
            }
        }

        // Elimina una persona de la lista
        public string BorrarPersona(Persona persona)
        {
            try
            {
                var personaEncontrada = personas.FirstOrDefault(p => p.PersonaId == persona.PersonaId);
                if (personaEncontrada != null)
                {
                    personas.Remove(personaEncontrada);
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
