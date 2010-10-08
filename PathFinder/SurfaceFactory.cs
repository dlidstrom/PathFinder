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
      /// <returns>Surface bitmap</returns>
      public static Bitmap CreateSurface(int width, int height)
      {
         var bitmap = new Bitmap(width, height);
         for (int x = 0; x < bitmap.Width; x++)
         {
            bitmap.SetPixel(x, 0, Color.Black);
            bitmap.SetPixel(x, bitmap.Height - 1, Color.Black);
         }

         for (int y = 0; y < bitmap.Height; y++)
         {
            bitmap.SetPixel(0, y, Color.Black);
            bitmap.SetPixel(bitmap.Width - 1, y, Color.Black);
         }

         return bitmap;
      }
   }
}