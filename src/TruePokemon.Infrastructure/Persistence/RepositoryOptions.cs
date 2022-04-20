using System.ComponentModel.DataAnnotations;

namespace TruePokemon.Infrastructure.Persistence;

public class RepositoryOptions
{
    [Required] public string? ConnectionString { get; set; }
}