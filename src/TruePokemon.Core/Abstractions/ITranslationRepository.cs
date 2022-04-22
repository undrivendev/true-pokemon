namespace TruePokemon.Core.Abstractions;

public interface ITranslationService
{
    public Task<string?> Translate(string input, CancellationToken cancellationToken = default);
}