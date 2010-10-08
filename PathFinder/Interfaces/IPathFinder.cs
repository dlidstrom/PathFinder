// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the IPathFinder interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder.Interfaces
{
   using System.Drawing;

   /// <summary>
   /// Defines the interface of path finders.
   /// </summary>
   public interface IPathFinder
   {
      /// <summary>
      /// Finds a path between startPoint and endPoint.
      /// </summary>
      /// <param name="startPoint">Starting point</param>
      /// <param name="endPoint">Ending point</param>
      /// <returns>Path that connects start and end point</returns>
      Path FindPath(Point startPoint, Point endPoint);
   }
}