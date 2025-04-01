# 📝 BrextCRUD

BrextCRUD es una API REST construida en .NET 8 que permite gestionar entidades relacionadas con la geografía, como países, regiones y ciudades. La aplicación está dockerizada y desplegada en Azure con un **pipeline CI/CD automatizado**.

🚀 **Desarrollado por Camilo Chaparro - Ingeniero de Sistemas Y Computación**

---

## ⚙️ Características
✅ API REST en .NET 8 con Clean Architecture  
✅ Base de datos en **Azure SQL Database**  
✅ Dockerizado y desplegado en **Azure Web Apps**  
✅ Pipeline **CI/CD con GitHub Actions y Docker Hub**  


## 🔧 Tecnologías
- **.NET 8**
- **Entity Framework Core**
- **SQL Server (Azure SQL Database)**
- **Docker**
- **GitHub Actions (CI/CD)**
- **Azure Web Apps**


## 🛠️ Configuración Local

### 📌 1. Clonar el repositorio
```bash
git clone https://github.com/BrextCRUD/Backend.git
cd todoapp
```

### 📌 2. Configurar la base de datos
Configura la cadena de conexión en `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=tcp:tu-servidor.database.windows.net;Database=ToDoAppDb;User Id=tu-usuario;Password=tu-password"
}
```

### 📌 3. Ejecutar la aplicación
```bash
dotnet run --project API
```

La API estará disponible en `http://localhost:5296`

## 🐳 Ejecución con Docker

### 📌 1. Construir y ejecutar el contenedor
```bash
docker build -f API/Dockerfile -t brextcrud-api .
docker run -p 8080:80 brextcrud-api
```

La API estará disponible en `http://localhost:8080`

## 🚀 Despliegue en Azure con CI/CD
Cada vez que se hace un **push a `main`**, GitHub Actions:
1. **Compila y prueba** el código.
2. **Construye la imagen Docker**.
3. **Sube la imagen a Docker Hub**.
4. **Despliega automáticamente en Azure Web Apps**.

## 📤 CI/CD con GitHub Actions
Ubicación del pipeline: `.github/workflows/cicd.yml`

## 📬 Endpoints Principales

### 📌 CRUD Country
```
 /api/country
```

### 📌 CRUD Region
```
 /api/region
```

### 📌 CRUD City
```
 /api/city
```

