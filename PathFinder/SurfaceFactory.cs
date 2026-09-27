// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the SurfaceFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Drawing;

   /// <summary>
   /// Helper class that creates a suitable surface where to draw paths.
   /// The surface is enclosed with lines. These lines act as sentinels
   /// for the path finders.
   /// </summary>
   public static class SurfaceFactory
   {
      /// <summary>
      /// Create surface with the given size.
      /// </summary>
      /// <param name="width">Width of surface</param>
      /// <param name="height">Height of surface</param>
      /// <returns>Surface</returns>
      public static Surface CreateSurface(int width, int height)
      {
         var surface = new Surface(width, height);
         for (int x = 0; x < surface.Width; x++)
         {
            surface.SetPixel(x, 0, Color.Black);
            surface.SetPixel(x, surface.Height - 1, Color.Black);
         }

         for (int y = 0; y < surface.Height; y++)
         {
            surface.SetPixel(0, y, Color.Black);
            surface.SetPixel(surface.Width - 1, y, Color.Black);
         }

         return surface;
      }
   }
}