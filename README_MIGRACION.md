# Sistema de Gestión de Tarjetas con Entity Framework

## 📋 Descripción

Sistema completo de gestión de tarjetas, personas, consumos, acreditaciones y descuentos implementado con Entity Framework Core y base de datos SQLite. El proyecto ha sido migrado completamente de almacenamiento en memoria a persistencia en base de datos.

## 🔄 Cambios Implementados

### 1. Migración a Entity Framework

- ✅ **ControladoraPersona**: Migrada completamente a Entity Framework
- ✅ **ControladoraTarjeta**: Migrada completamente a Entity Framework
- ✅ **ControladoraConsumo**: Migrada completamente a Entity Framework
- ✅ **ControladoraDescuento**: Migrada completamente a Entity Framework
- ✅ **ControladoraAcreditacion**: Migrada completamente a Entity Framework

### 2. Base de Datos

- **Motor**: SQLite (compatible con Windows, macOS y Linux)
- **Archivo**: `DBregistros.db` (se crea automáticamente)
- **Configuración**: Entity Framework Code First

### 3. Funcionalidades

- ✅ **CRUD Completo** para todas las entidades
- ✅ **Relaciones** configuradas correctamente
- ✅ **Precarga de datos** automática
- ✅ **Transacciones** seguras
- ✅ **Manejo de errores** mejorado

## 🚀 Configuración para tu Compañero

### Requisitos Previos

- .NET 6.0 o superior
- Visual Studio 2022 o VS Code

### Pasos de Instalación

1. **Clonar el repositorio**

   ```bash
   git clone [URL_DEL_REPOSITORIO]
   cd Final_POO_2025
   ```

2. **Restaurar paquetes NuGet**

   ```bash
   dotnet restore
   ```

3. **Construir la solución**

   ```bash
   dotnet build
   ```

4. **Ejecutar la aplicación**
   - **Windows**: Abrir `Vista/Vista.csproj` en Visual Studio y ejecutar
   - **macOS/Linux**: Ejecutar la aplicación de consola de prueba:
     ```bash
     cd ConsoleTest
     dotnet run
     ```

### 🗃️ Base de Datos

La base de datos se crea automáticamente la primera vez que ejecutas la aplicación. El archivo `DBregistros.db` se generará en el directorio del proyecto.

#### Datos Precargados

- **4 Personas** con datos de ejemplo
- **2 Tarjetas** (1 débito, 1 crédito)
- **3 Descuentos** activos
- **3 Acreditaciones** de ejemplo

## 📁 Estructura del Proyecto

```
Final_POO_2025/
├── Entidades/          # Modelos de datos
├── Modelo/             # Context de Entity Framework
├── Controladora/       # Lógica de negocio (migrada a EF)
├── Vista/              # Interfaz gráfica (Windows Forms)
├── ConsoleTest/        # Aplicación de consola para pruebas
└── DBregistros.db      # Base de datos SQLite (se crea automáticamente)
```

## 🔧 Cambios Técnicos Implementados

### Controladoras Actualizadas

- **Patrón Singleton** mantenido
- **Using statements** para manejo correcto de DbContext
- **Include()** para carga de relaciones
- **Transacciones** automáticas con SaveChanges()
- **Manejo de excepciones** mejorado

### Configuración de Base de Datos

```csharp
// Context.cs - Configuración SQLite
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite(@"Data Source=DBregistros.db");
}
```

### Ejemplo de Uso de Controladora

```csharp
// Antes (en memoria)
private List<Persona> personas;

// Después (Entity Framework)
public List<Persona> ListarPersonas()
{
    using (var context = new Context())
    {
        return context.Personas.Include(p => p.Tarjetas).ToList();
    }
}
```

## 🎯 Beneficios de la Migración

1. **Persistencia**: Los datos se mantienen entre ejecuciones
2. **Escalabilidad**: Preparado para crecer a bases de datos más grandes
3. **Integridad**: Relaciones y restricciones en la base de datos
4. **Portabilidad**: SQLite funciona en cualquier plataforma
5. **Profesional**: Arquitectura lista para producción

## 🛠️ Comandos Útiles

```bash
# Construir toda la solución
dotnet build

# Ejecutar tests de consola
cd ConsoleTest && dotnet run

# Ver la base de datos (requiere SQLite browser)
# Abrir DBregistros.db con DB Browser for SQLite
```

## 📊 Verificación de Datos

Después de ejecutar la aplicación, puedes verificar que los datos se guardaron correctamente:

1. Los archivos `DBregistros.db` debe aparecer en el directorio raíz
2. La aplicación de consola muestra las estadísticas:
   - Personas: 4
   - Tarjetas: 2
   - Descuentos: 3
   - Acreditaciones: 3

## 🚨 Notas Importantes

- **Compatibilidad**: El proyecto funciona en Windows, macOS y Linux
- **Base de Datos**: Se crea automáticamente en la primera ejecución
- **Sin Configuración**: No necesitas instalar SQL Server ni configurar cadenas de conexión
- **Listo para usar**: Solo clona, construye y ejecuta

---

✅ **El proyecto está completamente migrado y listo para usar con persistencia de datos**
