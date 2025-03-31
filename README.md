# ✅ Todo CRUD API (.NET 8 + EF Core + SQLite)

A minimal RESTful API for managing todo items using ASP.NET Core Minimal APIs, Entity Framework Core, and SQLite.

---

## 🚀 Features

- Create, Read, Delete Todo items
- Uses Entity Framework Core for persistence
- SQLite as lightweight database
- Clean and minimal code structure
- Auto-migration support on startup

---

## 🛠️ Tech Stack

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core Minimal APIs
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- SQLite (In-process database)
- C#

---

## 📦 Getting Started

### 🔧 How to Run This Project

Follow these steps to run the project on your local machine:

1. **Clone the Repository**

```bash
git clone https://github.com/yourusername/todo-minimal-api.git
cd todo-minimal-api
```

2. **Install EF Core CLI (if not installed)**

```bash
dotnet tool install --global dotnet-ef
```

3. **Restore Project Dependencies**

```bash
dotnet restore
```

4. **Apply Database Migrations**

```bash
dotnet ef migrations add InitialCreate
```

Then apply the migration:

```bash
dotnet ef database update
```

> ⚠️ If the migration already exists, you can skip the `add InitialCreate` step.

5. **Run the API**

```bash
dotnet run
```

> The app will start on `http://localhost:5000` or another port shown in your terminal.

---

## 📬 API Endpoints

| Method | Endpoint           | Description             |
|--------|--------------------|-------------------------|
| GET    | `/`                | Get all todos           |
| GET    | `/todo/{id}`       | Get a todo by ID        |
| POST   | `/todo`            | Create a new todo       |
| DELETE | `/todo/{id}`       | Delete a todo by ID     |

---

## 🗃️ Sample Todo Model

```json
{
  "id": 1,
  "name": "Finish .NET API",
  "duedate": "2025-04-01T00:00:00",
  "isComplete": false
}
```

---

## 📁 Project Structure

```
📁 TodoCRUD/
├── Program.cs              # Minimal API and endpoints
├── Todo.cs                 # Model class
├── TodoDbContext.cs        # EF Core DB context
├── Migrations/             # EF Core migration files
└── README.md               # Project documentation
```

---

## ✅ To Do / Improvements

- [ ] Add update (PUT/PATCH) endpoint
- [ ] Add input validation
- [ ] Add unit tests

---

## 🤝 License

MIT License. Use freely in your own projects!

---

## ✨ Credits

Created by [Asela Priyadarshana](https://github.com/zasealk)

