using System.Runtime.CompilerServices;

public static class EnsureThat
{
    public static void ItIsTrue_Simple(
        bool value,
        string message,
        [CallerArgumentExpression("value")] string paramName = "")
    {
        if (!value)
        {
            throw new ArgumentException(message, paramName);
        }
    }

    public static void ItIsTrue_Smart(
        bool value,
        [InterpolatedStringHandlerArgument("value")]
        ref EnsureInterpolatedStringHandler message,
        [CallerArgumentExpression("value")] string paramName = "")
    {
        if (!value)
        {
            throw new ArgumentException(message.ToString(), paramName);
        }
    }
}