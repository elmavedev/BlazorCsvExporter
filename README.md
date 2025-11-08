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

## 🆕 What's new in 1.0.5

- ✔️ **Deterministic builds** and full **SourceLink symbols** for better NuGet package health  
- ✔️ Fixed version mismatch between README and NuGet metadata  
- ✔️ Added **basic unit tests** for core CSV generation (initial coverage)  
- ✔️ Internal cleanup and improved build configuration  

This release consolidates all fixes and ensures the package passes all NuGet.org health checks ✅✅✅

---

## 📦 Installation

### Using .NET CLI
```bash
dotnet add package BlazorCsvExporter
```

This command will always pull the latest stable version from NuGet.org.

### Using PackageReference

You can also install the package via the NuGet Package Manager UI in Visual Studio.  
Your `.csproj` file will receive an entry similar to the following:

```xml
<ItemGroup>
  <PackageReference Include="BlazorCsvExporter" Version="x.y.z" />
</ItemGroup>
```

> The exact version (`x.y.z`) will be managed by NuGet when using the CLI command above.

---

## 🔧 JavaScript Setup

`BlazorCsvExporter` requires a small JavaScript helper to handle file downloads.  
If you are using the **included demo project**, this script is already referenced.  

However, if you install the library **directly from NuGet** in your own Blazor app,  
you need to add the following line manually in your host page:

### 👉 For Blazor WebAssembly
Add this line in `wwwroot/index.html`, right before the Blazor script:

```html
<script src="_content/BlazorCsvExporter/csvDownloader.js"></script>
<script src="_framework/blazor.web.js"></script>
```

### 👉 For Blazor Server
Add this line in `Pages/_Host.cshtml` (or `_Layout.cshtml` if applicable), right before `blazor.server.js`:

```html
<script src="_content/BlazorCsvExporter/csvDownloader.js"></script>
<script src="_framework/blazor.server.js"></script>
```

This script defines the global object `window.BlazorCsvExporter`  
and the function `downloadFile(...)` used internally by the component.  
Without this reference, the export button will throw an error such as:

```
Could not find 'BlazorCsvExporter.downloadFile' ('BlazorCsvExporter' was undefined)
```

Once the script is included, the download feature should work correctly in any Blazor app.

---

## 🚀 Quick Start Example

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

| Parameter | Type | Description |
|------------|------|-------------|
| `Items` | `IEnumerable<T>` | Data source for the CSV file |
| `FileName` | `string` | Name of the file when downloaded |
| `ShowPreview` | `bool` | Shows or hides the live CSV preview |

---

## 🧪 Demo Project

The repository includes a working demo under `BlazorCsvExporter.Demo`.

Run it with:
```bash
dotnet run --project BlazorCsvExporter.Demo
```

---

## 📝 License

This library is licensed under the **MIT License**.  
You are free to use it in both commercial and personal projects.

---

## 💬 Feedback & Support

If you find bugs or want to suggest improvements:  
👉 Open an issue on GitHub: https://github.com/elmavedev/BlazorCsvExporter/issues

If this project saves you time, please ⭐ it on GitHub!
