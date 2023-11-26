using CsvHelper;
using System.Globalization;

class DocFile
{
    public static void Write<T>(string filename, List<T> data)
    {
        using var writer = new StreamWriter(filename);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(data);
    }

    public static List<T> Read<T>(string filename)
    {
        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<T>().ToList();
        }
    }
}