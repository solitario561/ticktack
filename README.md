# ticktack

Este proyecto se encuentra dividido en tres secciones: **Backend**, **Frontend** y **DTOs** compartidos. A continuación, encontrarás las instrucciones para configurar y ejecutar el sistema.

---

## 🚀 Descarga e Instalación

1. **Clonar o descargar el repositorio:**
   - Puedes clonar el repositorio utilizando Git:
     ```bash
     https://github.com/solitario561/ticktack.git
     ```
   - También puedes descargarlo como un archivo `.zip` directamente desde el repositorio de GitHub.

2. **Ejecución del Backend y Frontend:**
   - Para el **Frontend**, ejecuta:
     ```bash
     dotnet watch run
     ```
   - Para el **Backend**, ejecuta en una instancia separada:
     ```bash
     dotnet watch run
     ```

3. **Configuración adicional (opcional):**
   - Si experimentas problemas con los enlaces de producción o despliegue:
     - **Backend:** Redirecciona las **CORS** al entorno local en el archivo de configuración del servidor.
     - **Frontend:** Cambia la URI base para que no solicite credenciales de login para el host.

---

## 🛠️ Dependencias necesarias

### Backend
- El sistema utiliza **Entity Framework Core** como ORM para manejar la base de datos.
- **Configuración de base de datos:**
  1. Modifica las credenciales de conexión en el archivo `appsettings.Development.json` para que coincidan con tu instancia local de SQL Server.
  2. Ejecuta el siguiente comando para crear las tablas necesarias automáticamente:
     ```bash
     dotnet ef database update
     ```
- Las dependencias del backend se gestionan mediante **NuGet** y ya están incluidas.  
  Si encuentras problemas, verifica que todas las dependencias estén instaladas correctamente:
     ```bash
     dotnet restore
     ```

---

## ✨ Funcionalidad

### Inicio de sesión
- **Credenciales predeterminadas:**
  - Correo: `jcla50@hotmail.com`
  - Contraseña: `Abc123`

### Gestión de tareas
- Una vez dentro, accede al listado de tareas, donde podrás:
  - **Agregar** nuevas tareas.
  - **Eliminar** tareas existentes.
  - **Editar** tareas (incluyendo su estado).

La interfaz está diseñada para ser intuitiva y funcional, facilitando el manejo de las tareas.

---

## 📋 Notas finales

- En caso de problemas, revisa los **logs** generados por el sistema para diagnosticar errores.
- Si tienes dudas o sugerencias, no dudes en abrir un **issue** en este repositorio.

---

¡Gracias por usar nuestro sistema de gestión de tareas! 😊
