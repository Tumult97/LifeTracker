namespace LifeTracker.Domain.Extensions;

public static class FlagEnumExtension
{
    public static string[] GetActiveFlags<T>(this T flags) where T : Enum
    {
        if (Attribute.GetCustomAttribute(typeof(T), typeof(FlagsAttribute)) == null)
        {
            throw new ArgumentException("The type parameter must be an enum with the [Flags] attribute.");
        }
        
        var flagList = new List<string>();
        var enumValues = Enum.GetValues(flags.GetType());
        foreach (var value in enumValues)
        {
            if (flags.HasFlag((T)value))
            {
                flagList.Add(value.ToString()!);
            }
        }

        return flagList.ToArray();
    }
}