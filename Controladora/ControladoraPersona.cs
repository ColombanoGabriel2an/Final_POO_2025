using Entidades;
using Modelo;
using Microsoft.EntityFrameworkCore;

namespace Controladora
{
    public class ControladoraPersona
    {
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
        }

        // Lista todas las personas
        public List<Persona> ListarPersonas()
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Personas.Include(p => p.Tarjetas).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Persona>();
            }
        }

        // Crea una nueva persona en la base de datos
        public string CrearPersona(Persona persona)
        {
            try
            {
                using (var context = new Context())
                {
                    context.Personas.Add(persona);
                    context.SaveChanges();
                    return "Persona creada correctamente";
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al crear la persona: {ex.Message}";
            }
        }

        // Actualiza los datos de una persona existente
        public string ActualizarPersona(Persona persona)
        {
            try
            {
                using (var context = new Context())
                {
                    var personaExistente = context.Personas.FirstOrDefault(p => p.PersonaId == persona.PersonaId);
                    if (personaExistente != null)
                    {
                        personaExistente.Nombre = persona.Nombre;
                        personaExistente.Apellido = persona.Apellido;
                        personaExistente.DNI = persona.DNI;

                        context.SaveChanges();
                        return "Persona actualizada correctamente";
                    }
                    else
                    {
                        return "Persona no encontrada";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al actualizar la persona: {ex.Message}";
            }
        }

        // Elimina una persona de la base de datos
        public string BorrarPersona(Persona persona)
        {
            try
            {
                using (var context = new Context())
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
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al eliminar la persona: {ex.Message}";
            }
        }

        // Obtener persona por ID
        public Persona? ObtenerPersonaPorId(int personaId)
        {
            try
            {
                using (var context = new Context())
                {
                    return context.Personas.Include(p => p.Tarjetas).FirstOrDefault(p => p.PersonaId == personaId);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}