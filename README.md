# MiApi

API REST desarrollada con **ASP.NET Core** y **Entity Framework Core**, que permite gestionar **Usuarios** y **Productos**, incluyendo operaciones CRUD completas y una relación entre ambas entidades.  
Incluye frontend simple con HTML, CSS y JavaScript para interactuar con la API.

---

## 🚀 Tecnologías utilizadas

- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQL Server**
- **C#**
- **HTML, CSS y JavaScript**
- **Visual Studio Code**

---

## 📦 Funcionalidades principales

### 👤 Usuarios
- Crear usuarios
- Listar usuarios
- Actualizar usuarios
- Eliminar usuarios

### 📦 Productos
- Crear productos
- Listar productos
- Actualizar productos
- Eliminar productos
- Relación con usuario (FK `UserId`)

### ⚙️ Middleware
- Manejo global de errores
- Logging de peticiones HTTP

---

## 🗄️ Base de datos

La base de datos se genera automáticamente mediante migraciones de EF Core.

### Crear migración inicial

## 🌐 Endpoints principales

### Usuarios
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/user` | Lista todos los usuarios |
| POST | `/api/user` | Crea un usuario |
| PUT | `/api/user/{id}` | Actualiza un usuario |
| DELETE | `/api/user/{id}` | Elimina un usuario |

### Productos
| Método | Endpoint | Descripción |
|--------|----------|-------------|
| GET | `/api/producto` | Lista todos los productos |
| POST | `/api/producto` | Crea un producto |
| PUT | `/api/producto/{id}` | Actualiza un producto |
| DELETE | `/api/producto/{id}` | Elimina un producto |

---

## 🧪 Frontend incluido

El proyecto incluye un pequeño frontend en **wwwroot/** con:

- Formulario para crear usuarios
- Formulario para crear productos
- Listado de usuarios
- Listado de productos

Todo usando **fetch()** para consumir la API.

---

## ✨ Autor

**Sebastián Arias Rodríguez**  
Desarrollador Junior Full Stack  
San José, Costa Rica  
