var names = new[] { "HaulPlan", "DriverPlan", "HaulMax", "HaulViwer" };

var serialized = JsonSerializer.Serialize(names);

Console.WriteLine(serialized);