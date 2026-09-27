// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the AStarFactory type, used to create the A* path finder.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using Interfaces;

   /// <summary>
   /// Factory class used to create AStartPathFinder instances.
   /// </summary>
   public class AStarFactory : IPathFinderFactory
   {
      /// <summary>
      /// Creates an AStarPathFinder.
      /// </summary>
      /// <param name="surface">Surface (world)</param>
      /// <returns>Path finder</returns>
      public IPathFinder CreatePathFinder(Surface surface)
      {
         return new AStarPathFinder(surface);
      }
   }
}