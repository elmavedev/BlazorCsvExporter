namespace BlazorCsvExporter.Models
{
    /// <summary>
    /// Options used when generating a CSV file.
    /// </summary>
    public class CsvOptions
    {
        /// <summary>
        /// Whether the CSV should include a header row.
        /// </summary>
        public bool IncludeHeader { get; set; } = true;

        /// <summary>
        /// Delimiter used between fields (for example ";" or ",").
        /// </summary>
        public string Delimiter { get; set; } = ";";

        /// <summary>
        /// Optional list of property names to include.
        /// If null or empty, all public readable properties are exported.
        /// </summary>
        public IEnumerable<string>? Columns { get; set; }
    }
}
