// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Defines the Surface type, a cross-platform replacement for GDI+ bitmaps.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinder
{
   using System.Drawing;

   /// <summary>
   /// A surface where paths are located. This is a cross-platform
   /// replacement for the Windows-only <see cref="Bitmap"/> type.
   /// </summary>
   public class Surface
   {
      /// <summary>
      /// The pixel data of the surface.
      /// </summary>
      private readonly Color[,] Pixels;

      /// <summary>
      /// Initializes a new instance of the Surface class.
      /// </summary>
      /// <param name="width">Width of surface</param>
      /// <param name="height">Height of surface</param>
      public Surface(int width, int height)
      {
         this.Width = width;
         this.Height = height;
         this.Pixels = new Color[width, height];
      }

      /// <summary>
      /// Gets the width of the surface.
      /// </summary>
      public int Width
      {
         get;
         private set;
      }

      /// <summary>
      /// Gets the height of the surface.
      /// </summary>
      public int Height
      {
         get;
         private set;
      }

      /// <summary>
      /// Gets the color of the pixel at the given position.
      /// </summary>
      /// <param name="x">X coordinate</param>
      /// <param name="y">Y coordinate</param>
      /// <returns>Pixel color</returns>
      public Color GetPixel(int x, int y)
      {
         return this.Pixels[x, y];
      }

      /// <summary>
      /// Sets the color of the pixel at the given position.
      /// </summary>
      /// <param name="x">X coordinate</param>
      /// <param name="y">Y coordinate</param>
      /// <param name="color">Pixel color</param>
      public void SetPixel(int x, int y, Color color)
      {
         this.Pixels[x, y] = color;
      }
   }
}