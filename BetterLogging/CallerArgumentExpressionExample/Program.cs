using CallerArgumentExpressionExample;

var array = new int[0];

//EnsureThat.ItIsNotEmpty(Array.Empty<int>());

//EnsureThat.ItIsTrue();

(array.Length > 0).ItIsTrue();
