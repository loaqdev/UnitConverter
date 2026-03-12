namespace unit_converter.Services;

public class CalculateService
{
    private const decimal KelvinOffset = 273.15m;

    private static readonly Dictionary<string, decimal> LengthFactors = new(StringComparer.OrdinalIgnoreCase)
    {
        { "mm", 0.001m }, { "cm", 0.01m }, { "m", 1.0m }, { "km", 1000.0m }
    };

    private static readonly Dictionary<string, decimal> WeightFactors = new(StringComparer.OrdinalIgnoreCase)
    {
        { "mg", 0.001m }, { "g", 1.0m }, { "kg", 1000.0m }, { "t", 1000000.0m }
    };

    public decimal CalculateLength(decimal value, string from, string to)
        => ConvertByFactor(value, from, to, LengthFactors);

    public decimal CalculateWeight(decimal value, string from, string to)
        => ConvertByFactor(value, from, to, WeightFactors);

    public decimal CalculateTemperature(decimal value, string from, string to)
    {
        decimal celsius = from switch
        {
            "c" => value,
            "f" => (value - 32m) * 5m / 9m,
            "k" => value - KelvinOffset,
            _ => throw new ArgumentException($"Unsupported unit: {from}")
        };

        return to switch
        {
            "c" => celsius,
            "f" => (celsius * 9m / 5m) + 32m,
            "k" => celsius + KelvinOffset,
            _ => throw new ArgumentException($"Unsupported unit: {to}")
        };
    }

    private decimal ConvertByFactor(decimal value, string from, string to, Dictionary<string, decimal> factors)
    {
        if (!factors.TryGetValue(from, out decimal fromF) || !factors.TryGetValue(to, out decimal toF))
            throw new ArgumentException($"Invalid units: {from} or {to}");

        return (value * fromF) / toF;
    }
}