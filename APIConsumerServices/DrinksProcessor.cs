using System.Text.Json;
using drinks_info_console.Models;

namespace drinks_info_console.APIConsumerServices;

public class DrinksProcessor
{
    public static async Task<List<Category>> GetCategoriesListAsync()
    {
        ApiClientHelper.InitializeClient();

        List<Category> categoryList = new List<Category>();

        using (var stream = await ApiClientHelper.Client!.GetStreamAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list"))
        {
            var categories = await JsonSerializer.DeserializeAsync<Categories>(stream);

            categoryList = categories!.CategoryList!;
        }

        return categoryList;
    }

    internal static async Task<List<Drink>> GetDrinksListAsync(string category)
    {
        ApiClientHelper.InitializeClient();

        List<Drink> drinkList = new List<Drink>();

        using (var stream = await ApiClientHelper.Client!.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={category}"))
        {
            var drinks = await JsonSerializer.DeserializeAsync<Drinks>(stream);

            drinkList = drinks!.DrinkList!;
        }

        return drinkList;
    }

    internal static async Task<List<DrinkDetail>> GetDrinksDetailsAsync(string id)
    {
        ApiClientHelper.InitializeClient();

        List<DrinkDetail> drinkDetailList = new List<DrinkDetail>();

        using (var stream = await ApiClientHelper.Client!.GetStreamAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={id}"))
        {
            var details = await JsonSerializer.DeserializeAsync<DrinkDetails>(stream);

            drinkDetailList = details!.DrinkDetailList!;
        }

        return drinkDetailList;
    }
}
