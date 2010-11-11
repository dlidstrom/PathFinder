// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the Path type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Collections;
   using System.Collections.Generic;
   using System.Drawing;

   /// <summary>
   /// Path containing a number of points.
   /// </summary>
   public class Path : IEnumerable<Point>
   {
      /// <summary>
      /// The list of points that make up the path.
      /// </summary>
      private readonly List<Point> Points = new List<Point>();

      /// <summary>
      /// Initializes a new instance of the Path class.
      /// </summary>
      /// <param name="points">Points used to construct path</param>
      public Path(IEnumerable<Point> points)
      {
         this.Points.AddRange(points);
      }

      /// <summary>
      /// Gets the number of points in path.
      /// </summary>
      public int Count
      {
         get
         {
            return this.Points.Count;
         }
      }

      /// <summary>
      /// Add a point to the path.
      /// </summary>
      /// <param name="point">Point to add</param>
      public void Add(Point point)
      {
         this.Points.Add(point);
      }

      /// <summary>
      /// Get enumerator.
      /// </summary>
      /// <returns>Point enumerator</returns>
      public IEnumerator<Point> GetEnumerator()
      {
         return this.Points.GetEnumerator();
      }

      /// <summary>
      /// Get enumerator.
      /// </summary>
      /// <returns>Point enumerator</returns>
      IEnumerator IEnumerable.GetEnumerator()
      {
         return this.Points.GetEnumerator();
      }
   }
}