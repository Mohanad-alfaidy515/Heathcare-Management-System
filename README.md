🏥 Healthcare Management System

A scalable Healthcare Management System built with ASP.NET Core following Clean Architecture principles. The system is designed to simplify healthcare operations by managing patients, doctors, appointments, authentication, and administrative workflows through a secure and maintainable backend.

---

🚀 Key Features

👨‍⚕️ Doctor Management

- Create and manage doctor profiles
- Update doctor information
- Track doctor availability

🧑 Patient Management

- Register patients
- Manage patient records
- View patient information

📅 Appointment Management

- Schedule appointments
- Manage appointment status
- Connect doctors with patients

🔐 Authentication & Authorization

- Secure user authentication
- Role-based access control
- Enterprise-level authorization structure

🏢 Administrative Operations

- Manage healthcare workflows
- Handle system business modules
- Centralized data management

---

🏗️ Architecture

The project follows Clean Architecture principles to achieve:

- Separation of Concerns
- Maintainability
- Scalability
- Testability

Project Structure:

├── Core
│   ├── Entities
│   ├── Interfaces
│   ├── DTOs
│   └── Business Rules
│
├── Infrastructure
│   ├── Data Access
│   ├── Repositories
│   ├── Authentication
│   └── External Services
│
├── Shared
│   ├── Common Utilities
│   ├── Constants
│   └── Shared Models
│
└── Healthcare Management System
    ├── Controllers
    ├── APIs
    ├── Configuration
    └── Program.cs

---

🛠️ Technologies Used

- ASP.NET Core
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Dependency Injection
- Repository Pattern
- Clean Architecture

---

⚙️ Getting Started

Clone Repository

git clone https://github.com/Mohanad-alfaidy515/Heathcare-Management-System.git

Navigate to Project

cd Heathcare-Management-System

Configure Database

Update your connection string in:

appsettings.json

Run Migrations

dotnet ef database update

Run Project

dotnet run

---

🎯 Future Enhancements

- Online Consultation
- Medical Reports
- Notifications & Reminders
- Payment Integration
- AI-powered Health Assistant
- Mobile Application Support

---

👨‍💻 Developer

Mohanad Adel

Backend Developer (.NET)

GitHub:
https://github.com/Mohanad-alfaidy515

---

⭐ Contributing

Contributions, issues, and feature requests are welcome.

---

📄 License

This project is intended for educational and portfolio purposes.
