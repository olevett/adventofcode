using AdventOfCode2021;
using System.Reflection;

Console.WriteLine(
    string.Join(
        Environment.NewLine,
        Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(Day)))
            .Select(t => (Day)Activator.CreateInstance(t))
            .Select(day =>
            {
                var assembly = typeof(Day).Assembly;
                var resourceName = $"AdventOfCode2021.Inputs.{day.GetType().Name}.txt";

                string input = "";
                using (var stream = assembly.GetManifestResourceStream(resourceName))
                using (var reader = new StreamReader(stream))
                {
                    input = reader.ReadToEnd();
                }

                return $"{day.GetType().Name}, Part 1, {day.Part1(input)} expected {day.Part1Expected} {Environment.NewLine} " +
                    $"{day.GetType().Name}, Part 2, {day.Part2(input)} expected {day.Part2Expected}";
            })
        )
);
