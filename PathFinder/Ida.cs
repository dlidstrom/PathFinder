// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the Ida type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System;
   using System.Collections.Generic;
   using System.Drawing;
   using Interfaces;

   /// <summary>
   /// Class that finds paths using iterative-deepening A*.
   /// </summary>
   public class Ida : IPathFinder
   {
      /// <summary>
      /// Surface where paths are being located.
      /// </summary>
      private readonly Bitmap Surface;

      /// <summary>
      /// Compares points using distance to endpoint.
      /// </summary>
      private IComparer<Point> Comparer;

      /// <summary>
      /// Keeps track of visited points.
      /// </summary>
      private HashSet<Point> Visited = new HashSet<Point>();

      /// <summary>
      /// Initializes a new instance of the Ida class.
      /// </summary>
      /// <param name="surface">Surface where to find paths</param>
      public Ida(Bitmap surface)
      {
         this.Surface = surface;
      }

      /// <summary>
      /// Gets or sets the endpoint.
      /// </summary>
      private Point EndPoint
      {
         get;
         set;
      }

      /// <summary>
      /// Finds a path between startPoint and endPoint.
      /// </summary>
      /// <param name="startPoint">Starting point</param>
      /// <param name="endPoint">Ending point</param>
      /// <returns>Path that connects start and end point</returns>
      public Path FindPath(Point startPoint, Point endPoint)
      {
         this.EndPoint = endPoint;
         this.Comparer = new DistanceComparer(this.EndPoint);
         int costLimit = Utils.Distance(startPoint, endPoint);

         while (true)
         {
            var pathSoFar = new Stack<Point>();
            pathSoFar.Push(startPoint);
            this.Visited = new HashSet<Point> {startPoint};
            var result = this.DFS(0, startPoint, costLimit, pathSoFar);
            this.Visited.Remove(startPoint);
            if (result.Path != null)
            {
               return new Path(result.Path.ToArray());
            }
            if (result.CostLimit == int.MaxValue)
            {
               return null;
            }

            // update with new cost limit
            costLimit = result.CostLimit;
         }
      }

      /// <summary>
      /// Checks if point collides with anything in the vicinity.
      /// </summary>
      /// <param name="point">Point to check for collisions</param>
      /// <returns>true if point collides with existing points, false otherwise</returns>
      private bool Collides(Point point)
      {
         int neighbours = 0;
         foreach (var size in Constants.Directions)
         {
            var pt = Point.Add(point, size);
            var c = this.Surface.GetPixel(pt.X, pt.Y);
            if (c.A == 255)
            {
               return true;
            }

            if (this.Visited.Contains(pt))
            {
               neighbours++;
            }
         }

         return neighbours >= 2;
      }

      /// <summary>
      /// Returns solution. If there was no solution found the path will be null.
      /// </summary>
      /// <param name="startCost">Cost to get to this node</param>
      /// <param name="node">Current node</param>
      /// <param name="costLimit">Limit to the cost</param>
      /// <param name="pathSoFar">Path found so far</param>
      /// <returns>Solution with path or a null path if no solution found</returns>
      private Solution DFS(int startCost, Point node, int costLimit, Stack<Point> pathSoFar)
      {
         int minimumCost = startCost + Utils.Distance(node, this.EndPoint);
         if (minimumCost > costLimit)
         {
            return new Solution {CostLimit = minimumCost, Path = null};
         }

         if (node == this.EndPoint)
         {
            return new Solution {CostLimit = costLimit, Path = new Stack<Point>(pathSoFar.ToArray())};
         }

         int nextCostLimit = int.MaxValue;
         var successors = this.GetNeighbours(node);
         foreach (var succNode in successors)
         {
            int newStartCost = startCost + 1;
            pathSoFar.Push(succNode);
            this.Visited.Add(succNode);
            var solution = this.DFS(newStartCost, succNode, costLimit, pathSoFar);
            this.Visited.Remove(succNode);
            pathSoFar.Pop();
            if (solution.Path != null)
            {
               return solution;
            }

            nextCostLimit = Math.Min(nextCostLimit, solution.CostLimit);
         }

         return new Solution {CostLimit = nextCostLimit, Path = null};
      }

      /// <summary>
      /// Get valid neighbours of the point.
      /// </summary>
      /// <param name="point">Point with neighbours</param>
      /// <returns>List of valid neighbours</returns>
      private List<Point> GetNeighbours(Point point)
      {
         var points = new List<Point>(8);
         foreach (var size in Constants.Directions)
         {
            var pt = Point.Add(point, size);

            var collides = this.Collides(pt);
            if (!this.Visited.Contains(pt) && !collides)
            {
               points.Add(pt);
            }
         }

         // sort points so that closest to endPoint will be processed first
         points.Sort(this.Comparer);

         return points;
      }

      /// <summary>
      /// Solution type with cost limit and path. Path is null for invalid solutions.
      /// </summary>
      private class Solution
      {
         /// <summary>
         /// Gets or sets the cost limit.
         /// </summary>
         public int CostLimit
         {
            get;
            set;
         }

         /// <summary>
         /// Gets or sets path.
         /// </summary>
         public Stack<Point> Path
         {
            get;
            set;
         }
      }
   }
}