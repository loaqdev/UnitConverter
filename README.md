# Unit Converter (ASP.NET Core / JavaScript)

![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)

A versatile web-based unit converter that allows users to seamlessly convert units of **Length**, **Weight**, and **Temperature**. This project focuses on high calculation precision and a clean, modern web architecture.

The project idea was inspired by [roadmap.sh/projects/unit-converter](https://roadmap.sh/projects/unit-converter).

## Features
- **High Precision**: Built using the C# `decimal` type to eliminate floating-point errors (e.g., `0.1 + 0.2 = 0.30000000000000004`) common with the `double` type.
- **Three Categories**:
    - **Length**: Millimetres (mm), Centimetres (cm), Metres (m), Kilometres (km).
    - **Weight**: Milligrams (mg), Grams (g), Kilograms (kg), Tonnes (t).
    - **Temperature**: Celsius (°C), Fahrenheit (°F), Kelvin (K).
- **Modern UI**: A responsive, mobile-friendly interface using Flexbox, CSS gradients, and smooth transitions.
- **Request Optimization**: Implements `AbortController` in JavaScript to cancel pending requests when a user clicks the "Convert" button rapidly.
- **RESTful API**: Cleanly implemented ASP.NET Core controller following best practices.

## Tech Stack
- **Backend**: .NET 8/9 (ASP.NET Core Web API)
- **Frontend**: HTML5, CSS3, JavaScript (ES6+)
- **Libraries**: [Axios](https://axios-http.com/) for handling HTTP requests.

## Getting Started

### 1. Prerequisites
Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed (version 8.0 or higher).

### 2. Installation
Clone the repository to your local machine:
```bash
git clone https://github.com/loaqdev/GitHub-User-Activity.git
cd unit-converter
```

### 3. Running the Application
Start the server using the .NET CLI:
```bash
dotnet run
```

Once the application starts, open your browser and navigate to: https://localhost:5001 or http://localhost:5000.

### 4. Project Structure
- /Controllers — Handles API routing and request processing.
- /Services — Contains the business logic and unit conversion formulas.
- /Models — Defines the Data Transfer Objects (DTOs) for requests/responses.
- /wwwroot — Stores static frontend files (HTML, CSS, JS).

## Calculation Logic
To ensure accuracy and scalability, the service uses a Normalization Strategy:
The input value is first converted into a Base Unit (e.g., Metres for length, Grams for weight, or Celsius for temperature).
The base value is then converted into the Target Unit.
This approach minimizes the number of formulas required and makes it easy to add new units in the future.
