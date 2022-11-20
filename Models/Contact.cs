using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Models;

public class Contact
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string PhoneNumber { get; set; }
}
