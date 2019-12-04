using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Challenges.D3
{
    public class Day3Answer
    {
        public void RunChallenge1()
        {
            var input = ChallengeHelper.LoadInput2D<string>("D3", ',');
            var wires = GetWires(input, true);
            var crosses = GetCrosses(wires);
            var closest = GetClosestIntersection(crosses);

            Console.WriteLine($"Challenge 1: closest={closest}");
        }

        public void RunChallenge2()
        {
            var input = ChallengeHelper.LoadInput2D<string>("D3", ',');
            var wires = GetWires(input, true);
            var crosses = GetCrosses(wires);
            var closest = GetClosestIntersection(crosses);

            Console.WriteLine($"Challenge 2:");
        }

        private List<List<Point>> GetWires(List<List<string>> input, bool interpolatePaths)
        {
            List<List<Point>> points = new List<List<Point>>();
            foreach (var movements in input)
            {
                List<Point> wirePoints = new List<Point>();
                Point lastPoint = new Point(0, 0);
                //wirePoints.Add(lastPoint);

                foreach (var movement in movements)
                {
                    var direction = movement[0];
                    var distance = int.Parse(movement[1..]);

                    int x = 0;
                    int y = 0;
                    switch (direction)
                    {
                        case 'R': x += distance; break;
                        case 'L': x -= distance; break;

                        case 'U': y += distance; break;
                        case 'D': y -= distance; break;
                    }

                    int dX = lastPoint.X + x;
                    int dY = lastPoint.Y + y;

                    if (interpolatePaths)
                    {
                        if (x != 0)
                        {
                            IEnumerable<int> range = MakeRange(lastPoint.X, dX);
                            foreach (var item in range)
                            {
                                Point tmpPoint = new Point(item, dY);
                                wirePoints.Add(tmpPoint);
                            }
                        }
                        else
                        {
                            IEnumerable<int> range = MakeRange(lastPoint.Y, dY);
                            foreach (var item in range)
                            {
                                Point tmpPoint = new Point(dX, item);
                                wirePoints.Add(tmpPoint);
                            }
                        }

                    }

                    Point newPoint = new Point(dX, dY);
                    wirePoints.Add(newPoint);
                    lastPoint = newPoint;
                }
                points.Add(wirePoints);
            }

            return points;
        }

        private List<Point> GetCrosses(List<List<Point>> wires)
        {
            var crosses = wires[0].Intersect(wires[1]).ToList();
            return crosses;
        }

        private IEnumerable<int> MakeRange(int start, int end)
        {
            List<int> range = new List<int>();
            while (start != end)
            {
                if (start > end) { start--; }
                if (start < end) { start++; }
                range.Add(start);
            }
            return range;
        }

        private int GetClosestIntersection(List<Point> crosses)
        {
            List<int> manhatton = new List<int>();
            foreach (var cross in crosses)
            {
                manhatton.Add(Manhatton(new Point(0, 0), cross));
            }

            var closest = manhatton.OrderBy(x => x).First();
            return closest;
        }

        private int Manhatton(Point start, Point end)
        {
            if (start.X < 0) { start.X = Math.Abs(start.X); }
            if (start.Y < 0) { start.Y = Math.Abs(start.Y); }
            if (end.X < 0) { end.X = Math.Abs(end.X); }
            if (end.Y < 0) { end.Y = Math.Abs(end.Y); }

            int dX = Math.Abs(start.X - end.X);
            int dY = Math.Abs(start.Y - end.Y);
            return dX + dY;
        }
    }
}
