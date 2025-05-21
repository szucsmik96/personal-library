# Personal Library

This is a full-stack application that allows users to manage a personal library of books. It consists of:

- ✅ A **.NET (ASP.NET Core)** Web API for managing book data
- ✅ An **Angular** frontend for displaying and interacting with the data
- ✅ Uses **PrimeNG** UI components
- ✅ Implements CRUD operations (Create, Read, Update, Delete)

---

## 🧱 Technologies Used

### Backend
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core (SQL Server)
- C#

### Frontend
- Angular (v18)
- PrimeNG
- RxJS, Reactive Forms
- Angular Router

---

## ⚙️ Setup Instructions

### 🖥️ Backend (.NET)

1. Open `PersonalLibrary.sln` in Visual Studio
2. Make sure your `appsettings.Development.json` is configured to point to a local or SQL Server instance
2. Launch the application in debug mode using the HTTPS profile by clicking the "Start" button in the Visual Studio toolbar or pressing F5.

## ✅ Features

View a list of books
Add new books
Edit existing books
Delete books
Responsive UI with PrimeNG
Route-based form (create/edit based on ID)
Form validation with Angular Reactive Forms

## 🚀 Future Enhancements

Add authentication (login, roles)
Upload cover images for books
Add search and filter
Deploy to Azure
Introduce a generic abstraction layer for data access to improve flexibility and reusability
Add comprehensive unit, integration, and end-to-end (e2e) tests across the application