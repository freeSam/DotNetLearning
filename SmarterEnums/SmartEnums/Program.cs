using SmartEnums;

var free = Subscriptions.Free;
var freeToo = Subscriptions.Free;

var freeFromName = Subscriptions.FromName("Free");
var freeFromValue = Subscriptions.FromValue(1);

Console.WriteLine(freeFromValue == freeFromName);


Console.WriteLine($"Discount was {freeFromName.Discount}");