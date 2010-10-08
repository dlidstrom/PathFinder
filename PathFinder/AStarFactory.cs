// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the AStarFactory type, used to create the A* path finder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Drawing;

   using Interfaces;

   /// <summary>
   /// Factory class used to create AStartPathFinder instances.
   /// </summary>
   public class AStarFactory : IPathFinderFactory
   {
      /// <summary>
      /// Creates an AStarPathFinder.
      /// </summary>
      /// <param name="bitmap">Bitmap surface (world)</param>
      /// <returns>Path finder</returns>
      public IPathFinder CreatePathFinder(Bitmap bitmap)
      {
         return new AStarPathFinder(bitmap);
      }
   }
}