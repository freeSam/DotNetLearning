using System.Runtime.CompilerServices;

[InterpolatedStringHandler]
public ref struct EnsureInterpolatedStringHandler
{
    private DefaultInterpolatedStringHandler _innerHandler;

    public EnsureInterpolatedStringHandler(
        int literalLength, int formattedCount,
        bool condition, out bool shouldAppend)
    {
        if (condition)
        {
            _innerHandler = default;
            shouldAppend = false;
            return;
        }

        _innerHandler = new DefaultInterpolatedStringHandler(literalLength, formattedCount);
        shouldAppend = true;
    }

    public void AppendLiteral(string message)
    {
        _innerHandler.AppendLiteral(message);
    }

    public void AppendFormatted<T>(T message)
    {
        _innerHandler.AppendFormatted(message);
    }

    public override string ToString()
    {
        return _innerHandler.ToString();
    }

    public string ToStringAndClear()
    {
        return _innerHandler.ToStringAndClear();
    }
}