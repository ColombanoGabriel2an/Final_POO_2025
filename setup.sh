#!/bin/bash

echo "🚀 Configurando proyecto Final_POO_2025 con Entity Framework..."
echo ""

# Verificar que estamos en el directorio correcto
if [ ! -f "Final_POO_2025.sln" ]; then
    echo "❌ Error: No se encontró Final_POO_2025.sln"
    echo "Asegúrate de ejecutar este script desde el directorio raíz del proyecto"
    exit 1
fi

echo "📦 Restaurando paquetes NuGet..."
dotnet restore

echo ""
echo "🔨 Construyendo la solución..."
dotnet build

if [ $? -eq 0 ]; then
    echo ""
    echo "✅ Construcción exitosa!"
    echo ""
    echo "🗃️ Inicializando base de datos..."
    cd ConsoleTest
    dotnet run
    cd ..
    
    echo ""
    echo "✅ ¡Configuración completada exitosamente!"
    echo ""
    echo "📋 Próximos pasos:"
    echo "  • La base de datos SQLite se creó en: DBregistros.db"
    echo "  • Datos de ejemplo se cargaron automáticamente"
    echo "  • En Windows: Abrir Vista/Vista.csproj en Visual Studio"
    echo "  • En macOS/Linux: cd ConsoleTest && dotnet run"
    echo ""
    echo "📊 Datos precargados:"
    echo "  • 4 Personas de ejemplo"
    echo "  • 2 Tarjetas (débito y crédito)"
    echo "  • 3 Descuentos activos"
    echo "  • 3 Acreditaciones de ejemplo"
    echo ""
else
    echo "❌ Error en la construcción del proyecto"
    echo "Revisa los mensajes de error anteriores"
    exit 1
fi
