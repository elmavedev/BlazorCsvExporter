using BlazorCsvExporter.Models;
using BlazorCsvExporter.Services;
using Xunit;

namespace BlazorCsvExporter.Tests;

public class CsvServiceTests
{
    private record Person(string Name, int Age, string City);

    [Fact]
    public void GenerateCsv_IncludesHeader_WhenIncludeHeaderIsTrue()
    {
        // Arrange
        var data = new[]
        {
            new Person("Alice", 30, "Berlin"),
        };

        var options = new CsvOptions
        {
            IncludeHeader = true,
            Delimiter = ";"
        };

        var service = new CsvService();

        // Act
        var csv = service.GenerateCsv(data, options);

        // Assert
        Assert.Contains("Name;Age;City", csv);
        Assert.Contains("Alice;30;Berlin", csv);
    }

    [Fact]
    public void GenerateCsv_RespectsSelectedColumns()
    {
        // Arrange
        var data = new[]
        {
            new Person("Bob", 25, "Augsburg"),
        };

        var options = new CsvOptions
        {
            IncludeHeader = true,
            Delimiter = ";",
            Columns = new[] { "Name", "City" }
        };

        var service = new CsvService();

        // Act
        var csv = service.GenerateCsv(data, options);

        // Assert
        Assert.Contains("Name;City", csv);      // header
        Assert.Contains("Bob;Augsburg", csv);  // row
        Assert.DoesNotContain("25", csv);      // Age no debe aparecer
    }

    [Fact]
    public void GenerateCsv_EscapesDelimiterAndQuotes()
    {
        // Arrange
        var data = new[]
        {
            new Person("Foo; \"Bar\"", 42, "Munich"),
        };

        var options = new CsvOptions
        {
            IncludeHeader = false,
            Delimiter = ";"
        };

        var service = new CsvService();

        // Act
        var csv = service.GenerateCsv(data, options).TrimEnd();

        // Assert
        // campo completo con comillas y comillas internas duplicadas
        Assert.Equal("\"Foo; \"\"Bar\"\"\";42;Munich", csv);
    }
}
