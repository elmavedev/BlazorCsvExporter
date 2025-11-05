using System.Reflection;
using System.Text;
using BlazorCsvExporter.Models;

namespace BlazorCsvExporter.Services
{
    public class CsvService
    {
        /// <summary>
        /// Generates a CSV string for the given data and options.
        /// </summary>
        public string GenerateCsv<T>(IEnumerable<T> data, CsvOptions options)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (options is null)
                throw new ArgumentNullException(nameof(options));

            var type = typeof(T);

            var properties = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead);

            // Filter by Columns if provided
            if (options.Columns is { } cols && cols.Any())
            {
                var allowed = new HashSet<string>(cols);
                properties = properties.Where(p => allowed.Contains(p.Name));
            }

            var delimiter = string.IsNullOrEmpty(options.Delimiter)
                ? ";"
                : options.Delimiter;

            var sb = new StringBuilder();

            // Header
            if (options.IncludeHeader)
            {
                var header = string.Join(delimiter,
                    properties.Select(p => Escape(p.Name, delimiter)));

                sb.AppendLine(header);
            }

            // Rows
            foreach (var item in data)
            {
                var values = properties.Select(p =>
                {
                    var value = p.GetValue(item);
                    return Escape(value?.ToString() ?? string.Empty, delimiter);
                });

                sb.AppendLine(string.Join(delimiter, values));
            }

            return sb.ToString();
        }

        private static string Escape(string input, string delimiter)
        {
            if (input is null)
                return string.Empty;

            bool mustQuote =
                input.Contains(delimiter) ||
                input.Contains('"') ||
                input.Contains('\n') ||
                input.Contains('\r');

            // Double quotes inside quoted fields
            var value = input.Replace("\"", "\"\"");

            return mustQuote ? $"\"{value}\"" : value;
        }
    }
}
