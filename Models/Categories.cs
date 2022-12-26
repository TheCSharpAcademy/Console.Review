using System.Text.Json.Serialization;

namespace DrinksInfo.Models;

public record class Categories(
    [property: JsonPropertyName("drinks")] List<Category> categories
    );  
