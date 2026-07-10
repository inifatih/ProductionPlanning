# Production Planning System

A simple ASP.NET Core MVC application to balance weekly production planning and store the planning history into a SQL Server database using Entity Framework Core.

## Features

- Input weekly production planning (Monday–Sunday)
- Balance production across active working days
- Ignore days with production value `0`
- Save planning and adjusted result into SQL Server
- Display planning history

---

## Business Process

1. User enters the production quantity for each day.
2. The system calculates the total production of active days (values greater than 0).
3. The average production is calculated.
4. Any remaining production is distributed to the days with the highest production values.
5. The adjusted planning is displayed and stored in the database.

---

## Example

### Input

| Day | Value |
|-----|------:|
| Monday | 4 |
| Tuesday | 5 |
| Wednesday | 1 |
| Thursday | 7 |
| Friday | 6 |
| Saturday | 4 |
| Sunday | 0 |

### Output

| Day | Original | Adjusted |
|-----|---------:|---------:|
| Monday | 4 | 4 |
| Tuesday | 5 | 5 |
| Wednesday | 1 | 4 |
| Thursday | 7 | 5 |
| Friday | 6 | 5 |
| Saturday | 4 | 4 |
| Sunday | 0 | 0 |

---

## Technologies

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server

---

## Getting Started

### 1. Clone Repository

```bash
git clone https://github.com/<your-username>/<repository-name>.git
```

### 2. Open Project

Open the solution using **Visual Studio 2022**.

### 3. Restore Packages

```bash
dotnet restore
```

### 4. Create Database

Update the connection string in `appsettings.json` if needed.

Run the migration:

```bash
dotnet ef database update
```

Or using Package Manager Console:

```powershell
Update-Database
```

### 5. Run Application

```bash
dotnet run
```

Or press **Ctrl + F5** in Visual Studio.

Open:

```
https://localhost:xxxx
```

---

## Database

The application uses two tables:

- **Planning**
- **PlanningDetail**

Planning stores transaction information, while PlanningDetail stores the original and adjusted production values for each day.

---

## Author

Muhammad Alfatih
