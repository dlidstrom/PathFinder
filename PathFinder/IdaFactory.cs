// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the IdaFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using Interfaces;

   /// <summary>
   /// Factory class used to create Ida path finders.
   /// </summary>
   public class IdaFactory : IPathFinderFactory
   {
      /// <summary>
      /// Creates an Ida path finder.
      /// </summary>
      /// <param name="surface">Surface (world)</param>
      /// <returns>Path finder</returns>
      public IPathFinder CreatePathFinder(Surface surface)
      {
         return new Ida(surface);
      }
   }
}