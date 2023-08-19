using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Json;
using System.Text;
using System.Xml.Serialization;
using CsvHelper;
using LmsClassLibrary.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SysTextJson = System.Text.Json.JsonSerializer;

namespace ConsoleApp;

public class Program
{
    public static ServiceProvider ConfigureServices()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath: Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var collection = new ServiceCollection();
        collection.AddDbContext<EposContext>
            (builder => builder.UseSqlServer(connectionString));
        return collection.BuildServiceProvider();
    }

    public static async Task Main()
    {
        // init data
        var provider = ConfigureServices();
        var context = provider.GetService<EposContext>();
        var faculties = await context.Faculty
            .Include(faculty => faculty.Departments)
            // .ThenInclude(department => department.Propositions)
            .ToListAsync();
    }

    public static async Task<CatFactDTO[]> PrintCatFacts()
    {
        try
        {
            // long way
            var client = new HttpClient();
            var response = await client.GetAsync("https://cat-fact.herokuapp.com/facts");
            var content = await response.Content.ReadAsStringAsync();
            var catFacts = JsonConvert.DeserializeObject<CatFactsModel[]>(content);
            // short way
            var catFacts2 = await SysTextJson.DeserializeAsync<CatFactsModel[]>
                (await new HttpClient().GetStreamAsync("https://cat-fact.herokuapp.com/facts"));
            // even shorter way
            var catFacts3 = await new HttpClient()
                .GetFromJsonAsync<CatFactsModel[]>("https://cat-fact.herokuapp.com/facts");
            var dtos = catFacts3
                .Select(fact =>
                    new CatFactDTO(DateOnly.FromDateTime(fact.createdAt),
                        fact.text)).ToArray();
            foreach (var dto in dtos)
            {
                Console.WriteLine(dto);
            }

            return dtos;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            return Array.Empty<CatFactDTO>();
        }
    }


    public static async Task<string> GetResource(string url)
    {
        // Створюємо екземпляр HttpClient
        using var httpClient = new HttpClient();
        // Визначаємо URL веб-сервісу
        try
        {
            // Надсилаємо GET-запит до веб-сервісу
            HttpResponseMessage response = await httpClient.GetAsync(url);
            // Переконуємося, що запит успішний
            response.EnsureSuccessStatusCode();
            // Отримуємо вміст відповіді як рядок
            string content = await response.Content.ReadAsStringAsync();
            // Виводимо вміст відповіді
            Console.WriteLine(content);
            return content;
        }
        catch (HttpRequestException exception)
        {
            var error = $"Error: {exception.Message}";
            Console.WriteLine(error);
            return error;
        }
    }

    static async Task SomeMethod()
    {
        using (var cts = new CancellationTokenSource())
        {
            // Запускаємо довготривалу операцію
            var longRunningTask = LongRunningOperationAsync(cts.Token);

            // Чекаємо 2 секунди
            await Task.Delay(2000);

            // Скасовуємо операцію
            cts.Cancel();

            try
            {
                await longRunningTask;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was canceled.");
            }
        }
    }

    static async Task LongRunningOperationAsync(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            // Перевіряємо, чи операцію було скасовано
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine($"Iteration {i + 1}");
            await Task.Delay(1000);
        }
    }

    public static void ToXml<T>(T data, string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var writer = new StreamWriter(fileName);
        serializer.Serialize(writer, data);
    }

    public static T FromXml<T>(string fileName)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StreamReader(fileName);
        return (T) serializer.Deserialize(reader);
    }

    public static void ToJsonNewtonsoft<T>(T data, string fileName) =>
        File.WriteAllText(fileName, JsonConvert.SerializeObject(data));

    public static T FromJsonNewtonsoft<T>(string fileName) =>
        JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));

    public static void ToJsonSystemText<T>(T data, string fileName) =>
        File.WriteAllText(fileName, SysTextJson.Serialize(data));

    public static T FromJsonSystemText<T>(string fileName) =>
        SysTextJson.Deserialize<T>(File.ReadAllText(fileName));

    public static async Task ToJsonAsyncSystemText<T>(T data, string fileName) =>
        await File.WriteAllTextAsync(fileName, SysTextJson.Serialize(data));

    public static async Task<T> FromJsonAsyncSystemText<T>(string fileName) =>
        SysTextJson.Deserialize<T>(await File.ReadAllTextAsync(fileName));

    public static void WriteToCsv(string filename, IEnumerable<DepartmentIdNameSlugDto> departments)
    {
        using var writer = new StreamWriter(filename);
        using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(departments);
    }

    public static DepartmentIdNameSlugDto[] GetFromCsv(string filename)
    {
        using var reader = new StreamReader(filename);
        using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csvReader.GetRecords<DepartmentIdNameSlugDto>().ToArray();
    }
}