# 🎓 Academic Management System

A full-stack **Academic Management System** built using **Angular (Standalone Components)** and **ASP.NET Core Web API**, designed to manage students, courses, professors, attendance, and marks in an educational institute.

This project demonstrates clean architecture, RESTful APIs, and modern Angular practices, making it suitable for **MCA final project**, **portfolio**, and **interview showcase**.

---

## 🚀 Tech Stack

### Frontend
- Angular (Standalone Components – latest approach)
- TypeScript
- HTML5 / CSS3
- Angular Router
- HttpClient
- FormsModule

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

---

## 📂 Project Structure

AcadProject
│
├── FrontEnd
│ └── academic-management-ui
│ ├── src/app
│ │ ├── students
│ │ ├── courses
│ │ ├── professors
│ │ ├── attendance
│ │ ├── marks
│ │ ├── services
│ │ └── login
│
└── Backend
└── AcademicManagementAPI
├── Controllers
├── Models
├── Data
└── Program.cs

yaml
Copy code

---

## ✨ Features

- 🔐 Login & Logout (basic authentication flow)
- 👨‍🎓 Student Management (Add / Edit / Delete / View)
- 📚 Course Management
- 👨‍🏫 Professor Management
- 📅 Attendance Tracking
- 📝 Marks Management
- 🌐 REST API integration
- 📖 Swagger API documentation
- 🎨 Clean and responsive UI

---

## 🧠 Learning Highlights

- Used **Angular standalone components** instead of NgModules
- Implemented **Angular routing**
- Integrated frontend with backend using **HttpClient**
- Designed **RESTful APIs** using ASP.NET Core
- Applied **Entity Framework Core** for database operations
- Practiced real-world **CRUD operations**
- Structured code for scalability and maintainability

---

## ▶️ How to Run the Project

### 🔹 Backend (ASP.NET Core API)

```bash
cd D:\AcadProject\Backend\AcademicManagementAPI
dotnet run
Open Swagger UI:

bash
Copy code
https://localhost:7034/swagger
🔹 Frontend (Angular)
bash
Copy code
cd D:\AcadProject\FrontEnd\academic-management-ui
ng serve
Open browser:

arduino
Copy code
http://localhost:4200
🔗 API Connection
Angular services communicate with the backend using:

bash
Copy code
https://localhost:7034/api/{ControllerName}
Make sure the backend is running before using frontend features.

📌 Future Enhancements
Role-based authentication (Admin / Teacher / Student)

JWT authentication

Pagination and search

UI improvements with Angular Material

Backend deployment (Azure / Railway)

Frontend deployment (Netlify)

👤 Author
Rajan Singh
🎓 MCA Graduate
💻 Full-Stack Developer (.NET & Angular)
🔗 GitHub: https://github.com/rjn24

📜 License
This project is created for educational and portfolio purposes.
