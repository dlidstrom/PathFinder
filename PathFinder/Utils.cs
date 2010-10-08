// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the Utils type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System;
   using System.Drawing;

   /// <summary>
   /// Utilities class.
   /// </summary>
   public static class Utils
   {
      /// <summary>
      /// Calculates the distance between two points.
      /// </summary>
      /// <param name="p1">First point</param>
      /// <param name="p2">Second points</param>
      /// <returns>Distance between p1 and p2, rounded down to integer</returns>
      public static int Distance(Point p1, Point p2)
      {
         var offset = (Size)p1 - (Size)p2;
         var distanceSquared = (offset.Height * offset.Height) + (offset.Width * offset.Width);
         return (int)Math.Floor(Math.Sqrt(distanceSquared));
      }
   }
}