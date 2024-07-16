namespace LifeTracker.Domain.Extensions;

public static class IsNullExtension
{
    public static bool IsNull<T>(this T? value) where T : class
    {
        return value == null;
    }
}