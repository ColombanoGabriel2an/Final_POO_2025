@echo off
echo ==================================================
echo       CONFIGURACION INICIAL DEL PROYECTO
echo ==================================================
echo.

echo 1. Eliminando migraciones anteriores...
cd Modelo
if exist "Migrations" rmdir /s /q "Migrations"
echo    ✓ Migraciones eliminadas

echo.
echo 2. Eliminando base de datos anterior...
cd ..
if exist "DBregistros.db" del "DBregistros.db"
if exist "Vista\bin\Debug\net6.0\DBregistros.db" del "Vista\bin\Debug\net6.0\DBregistros.db"
echo    ✓ Base de datos eliminada

echo.
echo 3. Creando nueva migración con datos iniciales...
cd Modelo
dotnet ef migrations add InitialWithSeedData
if %errorlevel% neq 0 (
    echo    ❌ Error al crear la migración
    pause
    exit /b %errorlevel%
)
echo    ✓ Migración creada

echo.
echo 4. Aplicando migración a la base de datos...
dotnet ef database update
if %errorlevel% neq 0 (
    echo    ❌ Error al aplicar la migración
    pause
    exit /b %errorlevel%
)
echo    ✓ Base de datos actualizada con datos iniciales

echo.
echo 5. Compilando todo el proyecto...
cd ..
dotnet build
if %errorlevel% neq 0 (
    echo    ❌ Error al compilar el proyecto
    pause
    exit /b %errorlevel%
)
echo    ✓ Proyecto compilado exitosamente

echo.
echo ==================================================
echo           CONFIGURACION COMPLETADA
echo ==================================================
echo.
echo ✓ Base de datos creada con datos iniciales
echo ✓ Proyecto listo para ejecutar
echo.
echo Ahora puedes:
echo - Ejecutar Vista (aplicación Windows Forms)
echo - Ejecutar ConsoleTest (aplicación de consola)
echo.
pause
