// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the DistanceComparer type which can be used to sort points.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Collections.Generic;
   using System.Drawing;

   /// <summary>
   /// Comparer that is used to sort points.
   /// </summary>
   public class DistanceComparer : IComparer<Point>
   {
      /// <summary>
      /// Point of reference.
      /// </summary>
      private readonly Point Point;

      /// <summary>
      /// Initializes a new instance of the DistanceComparer class.
      /// </summary>
      /// <param name="point">Point of reference</param>
      public DistanceComparer(Point point)
      {
         this.Point = point;
      }

      /// <summary>
      /// Compare two points. Distance to the member Point will determine order.
      /// </summary>
      /// <param name="first">First point</param>
      /// <param name="second">Second point</param>
      /// <returns>If first point is closer than second, -1. If distance equal, 0, otherwise 1</returns>
      public int Compare(Point first, Point second)
      {
         Size diff1 = (Size)(first - (Size)this.Point);
         int length1 = (diff1.Height * diff1.Height) + (diff1.Width * diff1.Width);

         Size diff2 = (Size)(second - (Size)this.Point);
         int length2 = (diff2.Height * diff2.Height) + (diff2.Width * diff2.Width);

         return length1.CompareTo(length2);
      }
   }
}