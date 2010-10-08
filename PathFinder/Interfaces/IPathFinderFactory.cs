// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the IPathFinderFactory interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder.Interfaces
{
   using System.Drawing;

   /// <summary>
   /// Defines the interface of path finder factories.
   /// </summary>
   public interface IPathFinderFactory
   {
      /// <summary>
      /// Creates a path finder.
      /// </summary>
      /// <param name="bitmap">Bitmap surface (world)</param>
      /// <returns>Path finder</returns>
      IPathFinder CreatePathFinder(Bitmap bitmap);
   }
}