namespace AdventOfCode2021
{
    public class Day2 : Day
    {
        public string Part1Expected => "1990000";

        public string Part2Expected => "1975421260";

        public string Part1(string input)
        {
            return input.Split(Environment.NewLine)
                .Aggregate(new Position(0, 0, 0), (state, line) =>
                 {
                     var position = line.Split(" ");
                     var amount = int.Parse(position[1]);
                     switch (position[0])
                     {
                         case "down":
                             return state with { Depth = state.Depth + amount };

                         case "up":
                             return state with { Depth = state.Depth - amount };

                         case "forward":
                             return state with { HorizontalPosition = state.HorizontalPosition + amount };
                     }
                     return state;
                 })
                .CurrentPosition().ToString();
        }

        public string Part2(string input)
        {
            return input.Split(Environment.NewLine)
              .Aggregate(new Position(0, 0, 0), (state, line) =>
              {
                  var position = line.Split(" ");
                  var amount = int.Parse(position[1]);
                  switch (position[0])
                  {
                      case "down":
                          return state with { Aim = state.Aim + amount };

                      case "up":
                          return state with { Aim = state.Aim - amount };

                      case "forward":
                          return state with { HorizontalPosition = state.HorizontalPosition + amount, Depth = state.Depth+(state.Aim*amount) };
                  }
                  return state;
              })
              .CurrentPosition().ToString();
        }

        public record Position(int Depth, int HorizontalPosition, int Aim)
        {
            public int CurrentPosition ()
            {
                return Depth * HorizontalPosition;
            }
        }
        
    }
}
