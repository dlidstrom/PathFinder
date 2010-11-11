// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the IdaFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Drawing;
   using Interfaces;

   /// <summary>
   /// Factory class used to create Ida path finders.
   /// </summary>
   public class IdaFactory : IPathFinderFactory
   {
      /// <summary>
      /// Creates an Ida path finder.
      /// </summary>
      /// <param name="bitmap">Bitmap surface (world)</param>
      /// <returns>Path finder</returns>
      public IPathFinder CreatePathFinder(Bitmap bitmap)
      {
         return new Ida(bitmap);
      }
   }
}