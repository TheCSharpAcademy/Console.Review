

using ConsoleTables;
using DrinksInfo.Models;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

var categories = await GetDrinksCategories(client);
Console.WriteLine("Welcome, please choose one of the following categories: \n");

WriteCategoryMenu(categories);

Console.WriteLine("Chosen Category:\n");
var chosenCat = Console.ReadLine();

var drinks =
    await GetDrinks(client, chosenCat);
    
Console.Clear();
WriteDrinksMenu(drinks);

Console.WriteLine("Chosen Drink:");
var chosenDrink = GetChosenDrink();


var drinkInfo = await GetDrinkInfo(client, chosenDrink);
Console.Clear();
WriteDrinkInfo(drinkInfo);





static async Task<Categories> GetDrinksCategories(HttpClient client)
{
    var json = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");
    var jsonString = json.Content.ReadAsStringAsync().Result; 
    var categories =
        JsonSerializer.Deserialize<Categories>(jsonString);
    return categories;
}

static async Task<Drinks> GetDrinks(HttpClient client,string chosenCat)
{
    try
    {
        var json = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/filter.php?c=" + chosenCat);
        var jsonString = json.Content.ReadAsStringAsync().Result;
        var drinks = JsonSerializer.Deserialize<Drinks>(jsonString);
        return drinks;
    }
    catch
    {
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        ClearCurrentConsoleLine();
        Console.SetCursorPosition(0, Console.CursorTop - 1);
        Console.WriteLine("There was a error, try again:");
        return await GetDrinks(client, Console.ReadLine());
    }
}

void WriteCategoryMenu(Categories categories)
{
    var table = new ConsoleTable("Drink Categories");

    foreach (var category in categories.categories)
    {
        table.AddRow(category.strCategory);
    }
    table.Write(Format.Alternative);
}

void WriteDrinksMenu(Drinks drinks)
{
    var table = new ConsoleTable("Drinks");
    foreach (var drink in drinks.drinks)
    {

        table.AddRow(drink.strDrink);
    }
    table.Write(Format.Alternative);
}

static async Task<Drink> GetDrinkInfo(HttpClient client, string chosenDrink)
{
    var json = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/search.php?s=" + chosenDrink);
    var jsonString = json.Content.ReadAsStringAsync().Result;
    var drinks = JsonSerializer.Deserialize<Drinks>(jsonString);
    var drink = drinks.drinks[0];
    return drink;
}

void WriteDrinkInfo(Drink drinkInfo)
{
    var table = new ConsoleTable(drinkInfo.strDrink + " Info", "");

    foreach (var str in drinkInfo.GetType().GetProperties())
    {
        if (str.GetValue(drinkInfo) != null)
        {
            table.AddRow(str.Name,str.GetValue(drinkInfo));
        }
    }
    table.Write(Format.Alternative);
}

string GetChosenDrink()
{
    var chosenDrink = Console.ReadLine();
    foreach (var json in drinks.drinks)
    {
        if (json.strDrink.ToLower() == chosenDrink.ToLower())
        {
            return chosenDrink;
        }
    }
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    ClearCurrentConsoleLine();
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.WriteLine(chosenDrink + " can't be found, try again:");
    return GetChosenDrink();
}

static void ClearCurrentConsoleLine()
{
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    for (int i = 0; i < Console.WindowWidth; i++)
        Console.Write(" ");
    Console.SetCursorPosition(0, currentLineCursor);
}