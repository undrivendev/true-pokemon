using System.ComponentModel.DataAnnotations;

namespace TruePokemon.Infrastructure;

public class BaseApiOptions
{
    [Required] public Uri? BaseUrl { get; set; }

    public string? HttpVersion { get; set; }
}