// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the IPathFinderFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder.Interfaces
{

   /// <summary>
   /// Defines the interface of path finder factories.
   /// </summary>
   public interface IPathFinderFactory
   {
      /// <summary>
      /// Creates a path finder.
      /// </summary>
      /// <param name="surface">Surface (world)</param>
      /// <returns>Path finder</returns>
      IPathFinder CreatePathFinder(Surface surface);
   }
}