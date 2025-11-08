# BlazorCsvExporter

[![NuGet Version](https://img.shields.io/nuget/v/BlazorCsvExporter.svg)](https://www.nuget.org/packages/BlazorCsvExporter)
[![NuGet Downloads](https://img.shields.io/nuget/dt/BlazorCsvExporter.svg)](https://www.nuget.org/packages/BlazorCsvExporter)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

**BlazorCsvExporter** is a lightweight Razor Class Library that allows you to dynamically generate, preview, and download CSV files directly from Blazor applications.  
Designed for developers who need instant CSV preview updates as users change options or filters.

---

## ✨ Features

- ✅ Generate CSV files from in-memory data  
- ✅ Real-time CSV preview with automatic updates  
- ✅ Simple Blazor component integration  
- ✅ Works with Blazor Server and WebAssembly (.NET 8.0)  
- ✅ No external dependencies required  

---

## 📦 Installation

### Using .NET CLI
```bash
dotnet add package BlazorCsvExporter --version 1.0.4
```

This command will always pull the latest stable version from NuGet.org.

### Using PackageReference

```xml
<ItemGroup>
  <PackageReference Include="BlazorCsvExporter" Version="1.0.1" />
</ItemGroup>
```

> The exact version (`x.y.z`) will be managed by NuGet when using the CLI command above.

---

## 🚀 Quick start

Add this line to your `_Imports.razor` file:

```razor
@using BlazorCsvExporter
```

Then use the exporter component in any Blazor page:

```razor
@page "/csv-demo"

<h3>CSV Export Demo</h3>

<!-- Replace parameter names with your actual implementation -->
<CsvExporter
    Items="@people"
    FileName="people.csv"
    ShowPreview="true" />

@code {
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string City { get; set; } = string.Empty;
    }

    private List<Person> people = new()
    {
        new Person { Name = "Alice", Age = 30, City = "Berlin" },
        new Person { Name = "Bob", Age = 25, City = "Augsburg" },
        new Person { Name = "Charlie", Age = 35, City = "Munich" }
    };
}
```

---

## ⚙️ Parameters

| Parameter    | Type            | Description                               |
|-------------|-----------------|-------------------------------------------|
| `Items`     | `IEnumerable<T>`| Data source for the CSV file             |
| `FileName`  | `string`        | Name of the file when downloaded         |
| `ShowPreview` | `bool`        | Shows or hides the live CSV preview      |

Update this table according to your final public API.

---

## 🧪 Demo Project

This repository contains a demo project that shows how to:

- Configure and use the CSV exporter
- Bind it to real data
- Use the dynamic preview before downloading the file

You can run the demo with:

```bash
dotnet run --project BlazorCsvExporter.Demo
```

---

## 📝 License

This library is licensed under the **MIT License**.  
You are free to use it in both commercial and personal projects.

---

## 💬 Feedback & contributions

If you find a bug, have an idea, or want to contribute:

- Open an issue: https://github.com/elmavedev/BlazorCsvExporter/issues
- Submit a pull request with improvements

If this library saves you time, please ⭐ the repository on GitHub!
