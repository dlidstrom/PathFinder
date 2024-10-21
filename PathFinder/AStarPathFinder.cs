// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the AStarPathFinder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Collections.Generic;
   using System.Drawing;
   using Interfaces;

   /// <summary>
   /// Pathfinder class using the A* algorithm.
   /// </summary>
   public class AStarPathFinder : IPathFinder
   {
      /// <summary>
      /// Surface where paths are being located.
      /// </summary>
      private readonly Bitmap Surface;

      /// <summary>
      /// Path end point.
      /// </summary>
      private Point EndPoint;

      /// <summary>
      /// Path start point.
      /// </summary>
      private Point StartPoint;

      /// <summary>
      /// Initializes a new instance of the AStarPathFinder class using the given surface.
      /// </summary>
      /// <param name="surface">Surface where to find paths</param>
      public AStarPathFinder(Bitmap surface)
      {
         this.Surface = surface;
      }

      /// <summary>
      /// Finds a path between startPoint and endPoint.
      /// </summary>
      /// <param name="startPoint">Starting point</param>
      /// <param name="endPoint">Ending point</param>
      /// <returns>Path that connects start and end point</returns>
      public Path? FindPath(Point startPoint, Point endPoint)
      {
         if (this.Collides(startPoint) || this.Collides(endPoint))
         {
            return null;
         }

         this.StartPoint = startPoint;
         this.EndPoint = endPoint;

         // initialize the open set of nodes with start point
         C5.IPriorityQueue<State> openSet = new C5.IntervalHeap<State>();

         // associate handles with points
         var handles = new Dictionary<Point, C5.IPriorityQueueHandle<State>>();

         // add start point to queue and associate point with handle
         C5.IPriorityQueueHandle<State>? handle = null;
         openSet.Add(ref handle!, new State {Point = startPoint, Heuristic = 0});
         handles.Add(this.StartPoint, handle);

         var closedSet = new HashSet<Point>();

         // the g-score is the distance from start point to the current point
         var gScore = new Dictionary<Point, double> {{startPoint, 0}};

         // the f-score is the g-score plus heuristic
         var fScore = new Dictionary<Point, double> {{startPoint, Utils.Distance(startPoint, this.EndPoint)}};

         // cameFrom is used to reconstruct path when target is found
         var cameFrom = new Dictionary<Point, Point>();

         // process nodes in the open set...
         while (!openSet.IsEmpty)
         {
            // fetch the highest priority node, i.e. the one with
            // the lowest heuristic value
            State minState = openSet.DeleteMin();
            Point x = minState.Point;
            handles.Remove(x);

            if (x == this.EndPoint)
            {
               // we found a solution
               return this.ReconstructPath(cameFrom);
            }

            closedSet.Add(x);
            var neighbours = this.GetNeighbours(x);

            // for each neighbour...
            foreach (var y in neighbours)
            {
               if (closedSet.Contains(y))
               {
                  continue;
               }

               // total cost from start
               var tentativeGScore = gScore[x] + Utils.Distance(x, y);

               bool tentativeIsBetter;
               Point point = y;
               handle = null;
               if (!handles.ContainsKey(point) && !closedSet.Contains(y))
               {
                  // will get priority adjusted further down
                  openSet.Add(ref handle!, new State {Point = point});
                  handles.Add(point, handle);
                  tentativeIsBetter = true;
               }
               else if (tentativeGScore < gScore[y])
               {
                  tentativeIsBetter = true;
               }
               else
               {
                  tentativeIsBetter = false;
               }

               if (tentativeIsBetter)
               {
                  // update f-score of y
                  cameFrom[y] = x;
                  gScore[y] = tentativeGScore;
                  fScore[y] = gScore[y] + Utils.Distance(y, this.EndPoint);
                  var heuristic = fScore[y];

                  // set priority of y
                  if (handle == null)
                  {
                     handle = handles[point];
                  }

                  openSet.Replace(handle, new State {Heuristic = heuristic, Point = y});
               }
            }
         }

         return null;
      }

      /// <summary>
      /// Checks if point collides with anything in the vicinity.
      /// </summary>
      /// <param name="point">Point to check for collisions</param>
      /// <returns>true if point collides with existing points, false otherwise</returns>
      private bool Collides(Point point)
      {
         foreach (var size in Constants.Directions)
         {
            var pt = Point.Add(point, size);
            var c = this.Surface.GetPixel(pt.X, pt.Y);
            if (c.A == 255)
            {
               return true;
            }
         }

         return false;
      }

      /// <summary>
      /// Get neighbour points. Only points that don't collide are considered valid neighbours.
      /// </summary>
      /// <param name="point">Point with neighbours</param>
      /// <returns>List of valid neighbours</returns>
      private List<Point> GetNeighbours(Point point)
      {
         var points = new List<Point>(8);
         foreach (var size in Constants.Directions)
         {
            var pt = Point.Add(point, size);

            bool collides = this.Collides(pt);
            if (!collides)
            {
               points.Add(pt);
            }
         }

         return points;
      }

      /// <summary>
      /// Reconstruct path.
      /// </summary>
      /// <param name="cameFrom">Point to point mapping used to reconstruct path</param>
      /// <returns>Path from start point to endpoint</returns>
      private Path ReconstructPath(IDictionary<Point, Point> cameFrom)
      {
         var points = new Stack<Point>();
         points.Push(this.EndPoint);
         Point p = cameFrom[this.EndPoint];
         while (p != this.StartPoint)
         {
            points.Push(p);
            p = cameFrom[p];
         }

         points.Push(this.StartPoint);
         return new Path(points.ToArray());
      }
   }
}
