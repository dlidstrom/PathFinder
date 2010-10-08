// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the State type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System;
   using System.Drawing;

   /// <summary>
   /// Defines a state which is a point with a heuristic value.
   /// </summary>
   public class State : IComparable<State>
   {
      /// <summary>
      /// Gets or sets the heuristic value.
      /// </summary>
      public int Heuristic
      {
         get;
         set;
      }

      /// <summary>
      /// Gets or sets the point.
      /// </summary>
      public Point Point
      {
         get;
         set;
      }

      /// <summary>
      /// Compare by heuristic value.
      /// </summary>
      /// <param name="other">Other state</param>
      /// <returns>If first heuristic is smaller than second, -1. If equal, 0, otherwise 1</returns>
      public int CompareTo(State other)
      {
         return this.Heuristic.CompareTo(other.Heuristic);
      }

      /// <summary>
      /// Get hash code. Uses the point to generate hash code.
      /// </summary>
      /// <returns>State hash code</returns>
      public override int GetHashCode()
      {
         return this.Point.GetHashCode();
      }
   }
}