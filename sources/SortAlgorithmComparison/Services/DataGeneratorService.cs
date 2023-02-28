using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;
using Waves.Core.Base.Attributes;

namespace SortAlgorithmComparison.Services;

/// <summary>
/// Data generator.
/// </summary>
[WavesPlugin(typeof(DataGeneratorService))]
public class DataGeneratorService
{
    private readonly RandomizerNumber<int> _generator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataGeneratorService"/> class.
    /// </summary>
    public DataGeneratorService()
    {
        _generator = new RandomizerNumber<int>(new FieldOptionsInteger()
        {
            Min = -500,
            Max = 500,
            UseNullValues = false,
            ValueAsString = false,
        });
    }

    /// <summary>
    /// Generates data array.
    /// </summary>
    /// <param name="n">Number of output elements.</param>
    /// <returns>Returns random data.</returns>
    public Task<int[]> Generate(int n)
    {
        var result = new int[n];

        for (var i = 0; i < n; i++)
        {
            result[i] = _generator.Generate() !.Value;
        }

        return Task.FromResult(result);
    }
}
