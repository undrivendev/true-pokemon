namespace TruePokemon.Core.Abstractions;

public interface ITranslationRepository
{
    public Task<string?> Translate(string input, CancellationToken cancellationToken = default);
}