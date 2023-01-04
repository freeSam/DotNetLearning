using System.Runtime.CompilerServices;

namespace CallerArgumentExpressionExample;

public static class Extensions
{
    public static void ItIsTrue(this bool value,
        [CallerArgumentExpression("value")] string message = "")
    {
        if (!value)
        {
            throw new ArgumentException(null, message);
        }
    }
}