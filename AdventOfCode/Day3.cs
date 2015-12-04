using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Helpers;

namespace AdventOfCode
{
    public class Day3
    {
        public int CalculateHouseVisits(string route)
        {
            var locationVisits = new Dictionary<Coordinate, int>();

            var currentLocation = new Coordinate(0, 0);
            locationVisits.AddOrUpdate(currentLocation, 1, (_, value) => value++);

            foreach (var movement in route.ToCharArray())
            {
                currentLocation = currentLocation.Move(movement);
                locationVisits.AddOrUpdate(currentLocation, 1, (_, value) => value++);
            }
            return locationVisits.Values.Where(visitCount => visitCount > 0).Count();
        }

        public int CalculateRoboSantaHouseVisits(string route)
        {
            var locationVisits = new Dictionary<Coordinate, int>();

            var roboSantaLocation = new Coordinate(0, 0);
            var realSantaLocation = new Coordinate(0, 0);
            locationVisits.AddOrUpdate(roboSantaLocation, 1, (_, __) => 1);
            locationVisits.AddOrUpdate(realSantaLocation, 1, (_, __) => 1);

            var roboVisits = route.Where((c, i) => i % 2 == 1);
            var santaVisits = route.Where((c, i) => i % 2 == 0);

            foreach (var movement in santaVisits)
            {
                realSantaLocation = realSantaLocation.Move(movement);
                locationVisits.AddOrUpdate(realSantaLocation, 1, (_, v) => v++);
            }

            foreach (var movement in roboVisits)
            {
                roboSantaLocation = roboSantaLocation.Move(movement);
                locationVisits.AddOrUpdate(roboSantaLocation, 1, (_, v) => v++);
            }

            return locationVisits.Values.Where(visitCount => visitCount > 0).Count();
        }
    }

    public class Coordinate : Tuple<int, int>
    {
        public Coordinate(int x, int y)
            : base(x, y)
        {
        }

        public int X
        {
            get { return Item1; }
        }

        public int Y
        {
            get { return Item2; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Coordinate)obj;

            if (other.X != this.X) return false;
            if (other.Y != this.Y) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Coordinate Move(char movement)
        {
            switch (movement)
            {
                case '<':
                    return new Coordinate(X - 1, Y);
                case '^':
                    return new Coordinate(X, Y + 1);
                case 'v':
                    return new Coordinate(X, Y - 1);
                case '>':
                    return new Coordinate(X + 1, Y);
                default:
                    throw new ArgumentOutOfRangeException("movement");
            }
        }
    }
}
