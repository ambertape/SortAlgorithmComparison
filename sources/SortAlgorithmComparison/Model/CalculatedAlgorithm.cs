using Waves.UI.Charts.Drawing.Primitives;

namespace SortAlgorithmComparison.Model;

/// <summary>
/// Algorithm item.
/// </summary>
public class CalculatedAlgorithm
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatedAlgorithm"/> class.
    /// </summary>
    /// <param name="name">Algorithm item.</param>
    /// <param name="color">Color.</param>
    /// <param name="totalTime">Total calculation time.</param>
    public CalculatedAlgorithm(string name, WavesColor color, double totalTime)
    {
        Name = name;
        Color = color;
        TotalTime = totalTime;
    }

    /// <summary>
    /// Gets name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets color.
    /// </summary>
    public WavesColor Color { get; }

    /// <summary>
    /// Gets total calculation time.
    /// </summary>
    public double TotalTime { get; }
}
